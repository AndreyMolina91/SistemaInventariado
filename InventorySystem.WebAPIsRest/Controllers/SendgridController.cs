using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.WebAPIsRest.Controllers
{
    public class SendgridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
