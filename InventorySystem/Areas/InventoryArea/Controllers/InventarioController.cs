using InventorySystem.Data;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.InventoryArea.Controllers
{
    [Area("InventoryArea")]
    [Authorize(Roles = StaticProperties.RoleAdmin+","+StaticProperties.RoleWorker)]
    public class InventarioController : Controller
    {
        //Para acceder a nuestros modelos y la información en las bases de datos
        private readonly ApplicationDbContext _context;

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
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
