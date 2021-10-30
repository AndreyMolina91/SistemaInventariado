using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Utilities
{
    //Implementamos la interfaz emailsender para ello instalamos Microsoft.AspNetCore.Identity.UI
    public class Emailing : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }

        //Una vez implementada la interfaz vamos al StartUp a injectar el servicio 
    }
}
