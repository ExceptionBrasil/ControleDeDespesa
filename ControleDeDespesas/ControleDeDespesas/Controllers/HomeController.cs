using Persistencia.DAO;
using Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Modelos;

namespace ControleDeDespesas.Controllers
{   
   
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Metodo responsável por fazer a atutenticação do usuário 
        /// </summary>
        /// <param name="autenticacao">The autenticacao.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Autentica(Autenticacao autenticacao)
        {
            if (WebSecurity.Login(autenticacao.Login, autenticacao.Senha))
            {
                

                //Cria a Sessão de página
                CadastroDeUsuario usuario = usuarioDAO.GetById(WebSecurity.GetUserId(autenticacao.Login));
                Session["Usuario"] = usuario;
                Session.Timeout = 15; 
                

                //Faz o retorno para o Ajax 
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