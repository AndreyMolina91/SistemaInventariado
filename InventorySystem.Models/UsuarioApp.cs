using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class UsuarioApp : IdentityUser //Microsoft.Extensions.identity.Store nugget
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public string Direccion { get; set; }
    
        public string Ciudad { get; set; }
    
        public string Pais { get; set; }

        [NotMapped] //DataAnotations Schema, así no creamos este campo en la base de datos y lo usamos solo en la app
        public string Role { get; set; }


    }
}
