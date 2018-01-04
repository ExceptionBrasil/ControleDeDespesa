using BuildMenu;
using Modelos;
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
            return Json(new {success = true, menu = MakeMenu.Recovery(Controller)});
        }

        [HttpPost]
        public JsonResult GetByLocation(string Location)
        {
            CadastroDeUsuario usuario = (CadastroDeUsuario)Session["Usuario"];
            if (usuario!=null)
            {
                return Json(new { success = true, menu = MakeMenu.RecoveryByLocation(Location, usuario.Role) });
            }
            return Json(new { success = true, menu ="" });

        }
    }
}