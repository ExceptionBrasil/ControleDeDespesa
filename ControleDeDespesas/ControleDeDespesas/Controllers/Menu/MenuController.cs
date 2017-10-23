using BuildMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeDespesas.Controllers
{
    public class MenuController : Controller
    {
        

        [HttpPost]
        public JsonResult Get(string Controller)
        {
            return Json(new { menu = MakeMenu.Recovery(Controller)});
        }
    }
}