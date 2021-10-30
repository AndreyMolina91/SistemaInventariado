using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models.ViewModels
{
    public class ProductoViewModel
    {
        //Objetos que vamos a utilizar
        public Producto Producto { get; set; }

        //Para usar el selectlistitem debemos instalar el paquete aspnetcore.MVC.ViewFeatures
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

        public IEnumerable<SelectListItem> ListaMarcas { get; set; }

        public IEnumerable<SelectListItem> ListaPadre { get; set; }
    }
}
