using BuildMenu;
using Interfaces;
using Modelos;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ControleDeDespesas.Controllers
{
    public class AprovacaoController : Controller, ISetMenu
    {
        private DespesasDAO despesasDAO;
        private UsuariosDAO usuarioDAO;
        private CentroDeCustoDAO ccDAO;

        public AprovacaoController(DespesasDAO dep, UsuariosDAO user, CentroDeCustoDAO cc)
        {
            this.despesasDAO = dep;
            this.usuarioDAO = user;
            this.ccDAO = cc;
            BuildMenu();
        }

        public void BuildMenu()
        {
            MakeMenu.Add("Despesas", "Index", "Aprovacao", "Home", Role.User);
        }

        // GET: Aprovacao
        public ActionResult Index()
        {

            //Recupera a session para o cadasrtro de usuário
            CadastroDeUsuario usuario = (CadastroDeUsuario)Session["Usuario"];

            //Retorna todos os Centros de Custos de aprovação do usuário                        
            IList<CentroDeCusto> CCAutorizados = ccDAO.GetByAprovador(usuario);

            //Recupera a Lista das Despesas pendentes pra aprovação 
            ViewBag.UnApprovedRDV = despesasDAO.GetDespesasUnApproved(CCAutorizados);


            return View();
        }

        /// <summary>
        /// Realiza a aprovação de uma despesa 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Aprovar(int id)
        {
            if (!despesasDAO.AprovarDespesa(id, usuarioDAO.GetById(WebSecurity.CurrentUserId)))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Realiza a Reprovação de uma despesa 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Reprovar(int id)
        {
            if (!despesasDAO.ReprovarDespesa(id, usuarioDAO.GetById(WebSecurity.CurrentUserId)))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}