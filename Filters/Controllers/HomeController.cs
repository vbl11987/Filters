using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    //[HttpsOnly]
    [Profile]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        public ViewResult SecondAction() => View("Message", "This is the Second Action in the Home controller");   
    }
}
