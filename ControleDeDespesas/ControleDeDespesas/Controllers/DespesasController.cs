using ControleDeDespesas.Controllers.Filters;
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
    [AurizacaoFilter]
    public class DespesasController : Controller
    {
        private UsuariosDAO usuarioDAO;
        private TiposDeDespesasDAO tiposDAO;

        public DespesasController(UsuariosDAO userDAO, TiposDeDespesasDAO tpDAO)
        {
            this.usuarioDAO = userDAO;
            this.tiposDAO = tpDAO;
        }

        // GET: Despesas
        public ActionResult Index()
        {
            Session["Usuario"] = usuarioDAO.GetById(WebSecurity.CurrentUserId);
            return View();
        }

        public ActionResult FrmIncluir()
        {
            ViewBag.TiposDeDespesa = tiposDAO.Lista();

            return View();
        }


        public JsonResult Incluir(IList<DespesasJson> despesas)
        {

            return Json(new { success = true });
        }

    }
}