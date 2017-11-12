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
            if (String.IsNullOrEmpty(Controller))
            {
                return Json(new { success = false, menssage = "Controlle is null ou empty"});
            }

            return Json(new { success= true, menu = MakeMenu.Recovery(Controller)});
        }

        [HttpPost]
        public JsonResult GetByLocation(string Location)
        {
            if (String.IsNullOrEmpty(Location))
            {
                return Json(new { success = false, menssage = "Location is null ou empty" });
            }
            return Json(new { success = true ,menu = MakeMenu.RecoveryByLocation(Location) });
        }
    }
}