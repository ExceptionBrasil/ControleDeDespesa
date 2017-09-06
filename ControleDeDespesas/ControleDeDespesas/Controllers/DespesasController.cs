using ControleDeDespesas.Controllers.Filters;
using ControleDeDespesas.DAO;
using ControleDeDespesas.Factorys;
using ControleDeDespesas.Models;
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
        private DespesasDAO despesasDAO;
        private CadastroDeUsuario usuario;

        public DespesasController(UsuariosDAO userDAO, TiposDeDespesasDAO tpDAO, DespesasDAO depDao)
        {
            this.usuarioDAO = userDAO;
            this.tiposDAO = tpDAO;
            this.despesasDAO = depDao;
        }

        // GET: Despesas
        public ActionResult Index()
        {            
            Session["Usuario"] = usuarioDAO.GetById(WebSecurity.CurrentUserId);           

            return View();
        }


        /// <summary>
        /// FRMs the incluir.
        /// </summary>
        /// <returns></returns>
        public ActionResult FrmIncluir()
        {
            ViewBag.TiposDeDespesa = tiposDAO.Lista();

            return View();
        }

        /// <summary>
        /// Faz a inclusão de uma Despesa e retorna um Json, com o resultado
        /// </summary>
        /// <param name="despesasJson">The despesas json.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult  Incluir (IList<DespesasJson> despesasJson)
        {

            if (despesasJson == null)
            {
                return Json(new { success = false });
            }
           

            List<Despesas> despesas =  DespesasJsonToDespesas.GeraLista(despesasJson);

            
            //Completa algumas informações antes de gravar
            foreach (var it in despesas)
            {
                it.UsuarioInclusao = (CadastroDeUsuario) Session["Usuario"];  
                it.CentroDeCusto = it.UsuarioInclusao.CentroDeCusto;
            }

            despesasDAO.Inclui(despesas);

            return Json(new { success = true });
        }

    }
}