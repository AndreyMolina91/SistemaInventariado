using InventorySystem.DataAccess.Repositories.IRepositories;
using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.Admin.Controllers
{
    //Controlador vacio donde crearemos nuestros metodos get post update desde 0 integrandolo con la repo unidad de trabajo

    [Area("Admin")] //Indicamos el area a la cual pertenece el controlador
    [Authorize(Roles = StaticProperties.RoleAdmin+ "," +StaticProperties.RoleWorker)]//Usuarios autorizados
    public class ProductoController : Controller
    {
        //Ahora creamos nuestraa variable de tipo unidad de trabajo
        private readonly IWorkUnity _workunity;

        //Variable para la creación de las imagenes
        private readonly IWebHostEnvironment _hostEnvironment;

        //constructor para inicializar la unidad de trabajo
        public ProductoController(IWorkUnity workunity, IWebHostEnvironment hostEnvironment)
        {
            _workunity = workunity; //inicializamos nuestra variable unidad de trabajo con el constructor
            _hostEnvironment = hostEnvironment; //Inicializamos la variable para cargar nuestras imágenes...
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            //Para el uso de los modelos haremos uso de los ViewModels

            ProductoViewModel productoViewModel = new ProductoViewModel()
            {
                Producto = new Producto(),
                ListaCategorias = _workunity.Categoria.GetTAll().Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                }),
                ListaMarcas = _workunity.Marca.GetTAll().Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                }),
                ListaPadre = _workunity.Producto.GetTAll().Select(x=> new SelectListItem
                {
                    Text = x.Descripcion,
                    Value = x.Id.ToString()
                })

            };




            if(id == null)
            {
                //Si el id es null creamos una nueva bodega
                return View(productoViewModel);
            }
            //Si salta a este codigo es porque existe la bodega y vamos a actualizar
            productoViewModel.Producto = _workunity.Producto.GetT(id.GetValueOrDefault());
            if (productoViewModel.Producto == null)
            {
                return NotFound();
            }

            return View(productoViewModel);

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductoViewModel productoViewModel)
        {
            if (ModelState.IsValid)
            {

                //cargar imagenes
                string webRootPath = _hostEnvironment.WebRootPath;
                //guardamos la ruta de la imágen
                var files = HttpContext.Request.Form.Files;
                //Si la imágen fue seleccionada
                if(files.Count>0)
                {
                    string filename = Guid.NewGuid().ToString();
                    //Importamos system.IO para el uso de Path donde guardaremos la imagen
                    var uploads = Path.Combine(webRootPath, @"imgs\folder-productos\");
                    //Guardamos el filename de la imagen guardada  en el path
                    var extension = Path.GetExtension(files[0].FileName);

                    if (productoViewModel.Producto.UrlImagen!=null)
                    {
                        //Si se está editando una imagen existente debemos borrar la anterior y luego reemplazarla
                        var imagePath = Path.Combine(webRootPath, productoViewModel.Producto.UrlImagen.TrimStart('\\')); //TrimStart omite las 2 carpetas de los 2 primeros slash
                        if (System.IO.File.Exists(imagePath))
                        {
                            //Si existe la eliminamos
                            System.IO.File.Delete(imagePath);

                        }
                    }

                    using (var filesStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        //Copiamos al directorio ffilesstream
                        files[0].CopyTo(filesStreams);
                    }
                    //Creamos y guardamos la imagen
                    productoViewModel.Producto.UrlImagen = @"\imgs\folder-productos\" + filename + extension;
                    
                }

                else
                {
                    //Si en el update el usuario no cambia la imagen es diferente a 0 a la de producto id
                    if (productoViewModel.Producto.Id != 0)
                    {
                        //la variable productoDb contendra el producto obtenido con el metodo get de nuestro repo unidad de trabajo por id
                        Producto productoDb = _workunity.Producto.GetT(productoViewModel.Producto.Id);
                        productoViewModel.Producto.UrlImagen = productoDb.UrlImagen;
                    }

                }
                                  
                if (productoViewModel.Producto.Id == 0)
                {
                    _workunity.Producto.Add(productoViewModel.Producto);
                }
                else
                {
                    _workunity.Producto.Update(productoViewModel.Producto);
                }
                _workunity.SaveData();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //Cargamos categorias
                productoViewModel.ListaCategorias = _workunity.Categoria.GetTAll().Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                });

                //Cargamos marcas
                productoViewModel.ListaMarcas = _workunity.Marca.GetTAll().Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                });

                //Carga de productos con PadreId
                productoViewModel.ListaPadre = _workunity.Producto.GetTAll().Select(x => new SelectListItem
                {
                    Text = x.Descripcion,
                    Value = x.Id.ToString()
                });

                if (productoViewModel.Producto.Id!=0)
                {
                    productoViewModel.Producto = _workunity.Producto.GetT(productoViewModel.Producto.Id);
                }

            }
            return View(productoViewModel.Producto);
        }


        //Region para el uso de APIs

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetProducto = _workunity.Producto.GetTAll(includeprops: "Categoria,Marca");
            return Json(new { data = GetProducto }); //Datos en formato Json donde estamos pasando el metodo obtener todos los objetos a la variable GetBodegas
        }

        //Metodo API Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var GetProducto = _workunity.Producto.GetT(id);
            if (GetProducto == null)
            {
                return Json(new { success = false, message = "Error en el borrado del Producto" });
            }

            //Eliminar la imagen del directorio local, el eliminado de la base de datos ya lo realiza el workunity
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, GetProducto.UrlImagen.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _workunity.Producto.Remove(GetProducto);
            _workunity.SaveData();
            return Json(new { success = true, message = "Producto Eliminado correctamente" });
        }
        #endregion
    }
}
