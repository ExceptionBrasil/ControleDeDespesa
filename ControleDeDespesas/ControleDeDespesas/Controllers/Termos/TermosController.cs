using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeDespesas.Controllers.Termos
{
    /// <summary>
    /// Controller de aceite e Termos em geral 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class TermosController : Controller
    {
        private UsuariosDAO userDAO;

        public TermosController(UsuariosDAO u)
        {
            this.userDAO = u;
        }

        /// <summary>
        /// Exibe o Termo de Aceite de RDV
        /// </summary>
        /// <returns></returns>
        public ActionResult TermoDeAceiteRDV()
        {
            CadastroDeUsuario user = (CadastroDeUsuario)Session["Usuario"];
            if (user.TermoDeAceite != null)
            {
                return RedirectToAction("Index", "Despesas");
            }

            return View();
        }
        /// <summary>
        /// Post do Termo de aceite, através do request Json
        /// </summary>
        /// <param name="termo">The termo.</param>
        /// <returns></returns>
        public JsonResult TermoDeAceiteRDVPost(TermoModelView termo)
        {
            if (termo.Aceito)
            {

                //Adiciona ao usuário que ele leu o termo de aceite
                CadastroDeUsuario user = (CadastroDeUsuario)Session["Usuario"];
                user.TermoDeAceite = DateTime.Now;
                userDAO.Altera(user);

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }   
    }
}