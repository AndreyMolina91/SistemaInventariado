using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class DetalleInventario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InventarioId { get; set; }

        [ForeignKey("InventarioId")]

        [Required]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required]
        [Display(Name ="Stock Anterior")]
        public int StockAnterior { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
    }
}
