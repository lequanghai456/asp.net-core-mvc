using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoanRapphim.Areas.Admin.Controllers
{
    public class HomeController : BaseController

    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
