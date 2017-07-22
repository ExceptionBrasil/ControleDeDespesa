using ControleDeDespesas.Controllers.Filters;
using ControleDeDespesas.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ControleDeDespesas.Controllers
{
    [AurizacaoFilter]
    public class DespesasController : Controller
    {
        private UsuariosDAO usuarioDAO;

        public DespesasController(UsuariosDAO userDAO)
        {
            this.usuarioDAO = userDAO;
        }

        // GET: Despesas
        public ActionResult Index()
        {
            Session["Usuario"] = usuarioDAO.GetById(WebSecurity.CurrentUserId);
            return View();
        }

        public ActionResult FrmIncluir()
        {

            return View("Index");
        }
    }
}