using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                JObject nguoidung = JObject.Parse(HttpContext.Session.GetString("nguoidung"));
                int quyen = (int)nguoidung.SelectToken("PhanQuyen");
                if (quyen != 1)
                {
                    var url = Url.RouteUrl("default", new { controller = "Home", action = "Index" });
                    filterContext.Result = new RedirectResult(url);
                }    
                
            }
            catch (Exception err)
            {

                var url = Url.RouteUrl("default", new { controller = "Login", action = "Index" });
                filterContext.Result = new RedirectResult(url);
            }
        }
    }
}
