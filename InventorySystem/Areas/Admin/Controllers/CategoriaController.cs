using InventorySystem.DataAccess.Repositories.IRepositories;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.Admin.Controllers
{
    //Controlador vacio donde crearemos nuestros metodos get post update desde 0 integrandolo con la repo unidad de trabajo

    [Area("Admin")] //Indicamos el area a la cual pertenece el controlador
    public class CategoriaController : Controller
    {
        //Ahora creamos nuestraa variable de tipo unidad de trabajo
        private readonly IWorkUnity _workunity;

        //constructor para inicializar la unidad de trabajo
        public CategoriaController(IWorkUnity workunity)
        {
            _workunity = workunity; //inicializamos nuestra variable unidad de trabajo con el constructor
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Categoria categoria = new Categoria();
            if(id == null)
            {
                //Si el id es null creamos una nueva bodega
                return View(categoria);
            }
            //Si salta a este codigo es porque existe la bodega y vamos a actualizar
            categoria = _workunity.Categoria.GetT(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Id == 0)
                {
                    _workunity.Categoria.Add(categoria);
                }
                else
                {
                    _workunity.Categoria.Update(categoria);
                }
                _workunity.SaveData();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }


        //Region para el uso de APIs

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetCategoria = _workunity.Categoria.GetTAll();
            return Json(new { data = GetCategoria }); //Datos en formato Json donde estamos pasando el metodo obtener todos los objetos a la variable GetBodegas
        }

        //Metodo API Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var GetCategoria = _workunity.Categoria.GetT(id);
            if (GetCategoria == null)
            {
                return Json(new { success = false, message = "Error en el borrado de la Categoria" });
            }
            _workunity.Categoria.Remove(GetCategoria);
            _workunity.SaveData();
            return Json(new { success = true, message = "Categoria Eliminada correctamente" });
        }
        #endregion
    }
}
