using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    //[HttpsOnly]
    //[ProfileAsync]
    //[Profile]
    //[ViewResultDetail]
    //[ViewResultDetailAsync]
    //[ProfileHybrid]
    //[RangeException]
    //[TypeFilter(typeof(DiagnosticsFilter))]
    //[ServiceFilter(typeof(TimeFilter))]
    [Message("This is the Controller-Scoped Filter")]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter")]
        [Message("This is the Second Action-Scoped Filter")]
        //Changing the normal order of the filters
        [Message("This is the first Action-Scoped", Order = -1)]
        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        public ViewResult SecondAction() => View("Message", "This is the Second Action in the Home controller");

        public ViewResult GenerateException(int? id){
            if (id == null){
                throw new ArgumentNullException(nameof(id));
            } else if (id > 10){
                throw new ArgumentOutOfRangeException(nameof(id));
            } else {
                return View("Message", $"The value is {id}");
            }
        }   
    }
}
