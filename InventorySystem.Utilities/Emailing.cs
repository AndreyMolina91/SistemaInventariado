using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Utilities
{
    //Implementamos la interfaz emailsender para ello instalamos Microsoft.AspNetCore.Identity.UI
    public class Emailing : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        //Una vez implementada la interfaz vamos al StartUp a injectar el servicio 

        //Instalamos el paquete nugget de Sendgrid para el envio de email en el proyecto principal
        public Task Execute(string email, string subject, string mensaje)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = mensaje;
            mailMessage.From = new MailAddress("email");
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.sendgrid.net");
            smtp.Port = 587;
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("apikey", "keysendgrid-api-key");

            return smtp.SendMailAsync(mailMessage);
        }
    }
}
