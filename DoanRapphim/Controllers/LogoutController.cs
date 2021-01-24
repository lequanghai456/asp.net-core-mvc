using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            TempData.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
