using InventorySystem.DataAccess.Repositories.IRepositories;
using InventorySystem.Models;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.Admin.Controllers
{
    //Controlador vacio donde crearemos nuestros metodos get post update desde 0 integrandolo con la repo unidad de trabajo

    [Area("Admin")] //Indicamos el area a la cual pertenece el controlador
    [Authorize(Roles = StaticProperties.RoleAdmin)]
    public class MarcaController : Controller
    {
        //Ahora creamos nuestraa variable de tipo unidad de trabajo
        private readonly IWorkUnity _workunity;

        //constructor para inicializar la unidad de trabajo
        public MarcaController(IWorkUnity workunity)
        {
            _workunity = workunity; //inicializamos nuestra variable unidad de trabajo con el constructor
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Marca marca = new Marca();
            if(id == null)
            {
                //Si el id es null creamos una nueva bodega
                return View(marca);
            }
            //Si salta a este codigo es porque existe la bodega y vamos a actualizar
            marca = _workunity.Marca.GetT(id.GetValueOrDefault());
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Marca marca)
        {
            if (ModelState.IsValid)
            {
                if (marca.Id == 0)
                {
                    _workunity.Marca.Add(marca);
                }
                else
                {
                    _workunity.Marca.Update(marca);
                }
                _workunity.SaveData();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        //Region para el uso de APIs

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetMarca = _workunity.Marca.GetTAll();
            return Json(new { data = GetMarca }); //Datos en formato Json donde estamos pasando el metodo obtener todos los objetos a la variable GetBodegas
        }

        //Metodo API Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var GetMarca = _workunity.Marca.GetT(id);
            if (GetMarca == null)
            {
                return Json(new { success = false, message = "Error en el borrado de la Marca" });
            }
            _workunity.Marca.Remove(GetMarca);
            _workunity.SaveData();
            return Json(new { success = true, message = "Marca Eliminada correctamente" });
        }
        #endregion
    }
}
