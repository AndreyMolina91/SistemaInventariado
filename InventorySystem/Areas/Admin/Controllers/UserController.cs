using InventorySystem.Data;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticProperties.RoleAdmin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        #region APIs

        [HttpGet]
        public IActionResult Getall()
        {
            //Lista de usuarioApp model
            var userList = _context.Usuarios.ToList();
            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();

            foreach (var usuario in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == usuario.Id).RoleId;
                usuario.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

            }

            return Json(new { data = userList });
        }

        [HttpPost]
        //Al recibir del body el id
        public IActionResult LockUnlock([FromBody] string id)
        {
            string msgNotify = "";
            //creamos un objeto usuarios que coincida con el id recibido del body
            var user = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            //si no coincide con uno en la base de datos del context error de usuario
            if (user == null)
            {
                return Json(new { success = false, message = "Error de usuario" });
            }

            //si al contrario si existe el usuario y el lockoutend de ese usuario es mayor a la fecha actual se ejecuta el desbloqueo de usuario
            //poniendo ambas fechas iguales

            if(user.LockoutEnd!=null && user.LockoutEnd> DateTime.Now)
            {
                //Usuario bloqueado
                user.LockoutEnd = DateTime.Now;
                msgNotify = "Usuario desbloqueado exitosamente!";
            }
            else //De lo contrario es porque el usuario está desbloqueado y se quiere bloquear al usuario asi que le agregamos 1000 años a la fecha
            {
                //Bloquear usuario
                user.LockoutEnd = DateTime.Now.AddYears(1000);
                msgNotify = "Usuario bloqueado exitosamente!";
            }
            //guardamos cambios en la base de datos
            _context.SaveChanges();
            //Retornamos el Json con el mensaje de success ó 200 y nuestra variable string que contiene el mensaje de notificacion toastr en el JS
            return Json(new { success = true, message = msgNotify });
        }

        #endregion
    }
}
