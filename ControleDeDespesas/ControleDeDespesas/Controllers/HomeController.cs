using ControleDeDespesas.DAO;
using ControleDeDespesas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ControleDeDespesas.Controllers
{   
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private UsuariosDAO usuarioDAO; 

        public HomeController(UsuariosDAO userDao)
        {
            this.usuarioDAO = userDao;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("local", "CadastroDeUsuario", "Id", "Login", true);
            }
        }


        /// <summary>
        /// Home
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Metodo responsável por fazer a atutenticação do usuário 
        /// </summary>
        /// <param name="autenticacao">The autenticacao.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Autentica(Autenticacao autenticacao)
        {
            if (WebSecurity.Login(autenticacao.Login, autenticacao.Senha))
            {

                Session.Timeout = 30; // tempo em minutos                
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            WebSecurity.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}