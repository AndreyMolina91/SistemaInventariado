using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models.ViewModels
{
    public class InventarioViewModel
    {
        public Inventario Inventario { get; set; }

        public DetalleInventario DetalleInventario { get; set; }

        public List<DetalleInventario> DetalleInventarios { get; set; }

        public IEnumerable<SelectListItem> ListaBodegas { get; set; }

        public IEnumerable<SelectListItem> ListaProductos { get; set; }
    }
}
