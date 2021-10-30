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
    public class BodegaController : Controller
    {
        //Ahora creamos nuestraa variable de tipo unidad de trabajo
        private readonly IWorkUnity _workunity;

        //constructor para inicializar la unidad de trabajo
        public BodegaController(IWorkUnity workunity)
        {
            _workunity = workunity; //inicializamos nuestra variable unidad de trabajo con el constructor
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Bodega bodega = new Bodega();
            if(id == null)
            {
                //Si el id es null creamos una nueva bodega
                return View(bodega);
            }
            //Si salta a este codigo es porque existe la bodega y vamos a actualizar
            bodega = _workunity.Bodega.GetT(id.GetValueOrDefault());
            if (bodega==null)
            {
                return NotFound();
            }

            return View(bodega);

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.Id == 0)
                {
                    _workunity.Bodega.Add(bodega);
                }
                else
                {
                    _workunity.Bodega.Update(bodega);
                }
                _workunity.SaveData();
                return RedirectToAction(nameof(Index));
            }
            return View(bodega);
        }


        //Region para el uso de APIs

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetBodegas = _workunity.Bodega.GetTAll();
            return Json(new { data = GetBodegas }); //Datos en formato Json donde estamos pasando el metodo obtener todos los objetos a la variable GetBodegas
        }

        //Metodo API Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var GetBodega = _workunity.Bodega.GetT(id);
            if (GetBodega == null)
            {
                return Json(new { success = false, message = "Error en el borrado de la bodega" });
            }
            _workunity.Bodega.Remove(GetBodega);
            _workunity.SaveData();
            return Json(new { success = true, message = "Bodega Eliminada correctamente" });
        }
        #endregion
    }
}
