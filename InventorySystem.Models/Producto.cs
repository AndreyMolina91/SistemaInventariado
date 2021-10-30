using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name ="Código de producto")]
        public string SerieId { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Descripción de producto")]
        public string Descripcion { get; set; }

        [Required]
        [Range(1, 100000000)]
        [Display(Name = "Precio de producto")]
        public double Precio { get; set; }

        [Required]
        [Range(1, 100000000)]
        [Display(Name = "Costo de producto")]
        public double Costo { get; set; }

        public string  UrlImagen { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        //Recursividad

        public int? PadreId { get; set; }

        public virtual Producto Padre { get; set; }
    }
}
