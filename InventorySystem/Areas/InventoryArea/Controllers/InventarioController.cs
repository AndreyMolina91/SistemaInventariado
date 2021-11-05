using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace InventorySystem.Areas.InventoryArea.Controllers
{
    [Area("InventoryArea")]
    [Authorize(Roles = StaticProperties.RoleAdmin+","+StaticProperties.RoleWorker)]
    public class InventarioController : Controller
    {
        //Para acceder a nuestros modelos y la información en las bases de datos
        private readonly ApplicationDbContext _context;
        //llamamos al viewmodel
        //Durante la vista y cambios los daatos no cambien gracias al bindproperty
        [BindProperty]
        public InventarioViewModel _inventarioVM { get; set; }

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Create(int? inventarioId)
        {
            _inventarioVM = new InventarioViewModel();
            _inventarioVM.ListaBodegas = _context.Bodegas.ToList().Select(b => new SelectListItem
            {
                Text = b.Nombre,
                Value = b.Id.ToString()
            });
            _inventarioVM.ListaProductos = _context.Productos.ToList().Select(p => new SelectListItem
            {
                Text = p.Descripcion,
                Value = p.Id.ToString()
            });

            _inventarioVM.DetalleInventarios = new List<DetalleInventario>();

            //Si el inventario recibido por parametro es diferente a nulo = que existe
            if (inventarioId!=null)
            {
                //Accedemos a nuestro viewmodel que contiene la propiedad inventario - le asignamos lo que hay en Inventarios en su propiedad id que sea igual al id recibido por parametro
                _inventarioVM.Inventario = _context.Inventarios.SingleOrDefault(x => x.Id == inventarioId);
                //Tambien a nuestra propiedad lista detalle inventarios le asignamos lo que esta por medio de nuestro contexto de conexion dbset
                //y le incluimos la propiedad producto que es = al modelo producto para traer la informacion de los productos que pertenecen a este detalle inventarios de tipo list
                //Listamos toda la informacion
                _inventarioVM.DetalleInventarios = _context.DetalleInventarios.Include(x => x.Producto).Include(x => x.Producto.Marca).
                    Where(x => x.InventarioId == inventarioId).ToList();
            }
            //Retornamos la vista Create junto a la informacion cargada en nuestro viewmodel
            return View(_inventarioVM);
        }

        [HttpPost]
        //Las variables recibidas por parametros son los name de cada control de la vista Create ya que no serán inputs a los que le agregaremos data, sino que la data la cargan
        //por medio de dropdownlist
        public IActionResult Create(int producto, int cantidad, int inventarioId)
        {
            _inventarioVM.Inventario.Id = inventarioId;
            if (_inventarioVM.Inventario.Id == 0)
            {
                //Grabamos el registro nuevo en inventario
                _inventarioVM.Inventario.Estado = false;
                _inventarioVM.Inventario.FechaInicial = DateTime.Now;

                //capturamos el id del usuario
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
                _inventarioVM.Inventario.UsusarioAppId = claim.Value;

                //Agregamos los datos al model y guardamos
                _context.Inventarios.Add(_inventarioVM.Inventario);
                _context.SaveChanges();
            }
            else
            {
                _inventarioVM.Inventario = _context.Inventarios.SingleOrDefault(x => x.Id == inventarioId);
            }
            //variable bodegaProducto = contexto.dbsetproductos.incluir(variable => variable.Producto).primero(variable => variable.Producto = a variable por parametro
            //y variable.BodegaId = variableViewModel.Inventario.BodegaId
            var bodegaProducto = _context.BodegaProductos.Include(x => x.Producto).FirstOrDefault(x => x.ProductoId == producto && x.BodegaId == _inventarioVM.Inventario.BodegaId);

            var detalle = _context.DetalleInventarios.Include(x => x.Producto).FirstOrDefault(x => x.ProductoId == producto && x.InventarioId == _inventarioVM.Inventario.Id);

            //Si este detalle existe 
            if (detalle==null)
            {
                //Lo creamos
                _inventarioVM.DetalleInventario = new DetalleInventario();
                _inventarioVM.DetalleInventario.ProductoId = producto;
                _inventarioVM.DetalleInventario.InventarioId = _inventarioVM.Inventario.Id;
                if (bodegaProducto!=null)
                {
                    _inventarioVM.DetalleInventario.StockAnterior = bodegaProducto.Cantidad;

                }
                else
                {
                    _inventarioVM.DetalleInventario.StockAnterior = 0;
                }
                _inventarioVM.DetalleInventario.Cantidad = cantidad;
                _context.DetalleInventarios.Add(_inventarioVM.DetalleInventario);
                _context.SaveChanges();
            }
            else
            {
                detalle.Cantidad += cantidad;
                _context.SaveChanges();
            }

            return RedirectToAction("Create", new { inventarioId = _inventarioVM.Inventario.Id });
        }

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            //Nuestra variable contendrá del modelo bodega productos con include las propiedades de Bodega y Producto
            var GetBodegaProducto = _context.BodegaProductos.Include(x => x.Bodega).Include(x => x.Producto).ToList();

            //En el archivo Json diremos que data será todos los objetos de bodega y productos recibidos en la variable
            return Json(new {data = GetBodegaProducto});
        }

        #endregion
    }
}
