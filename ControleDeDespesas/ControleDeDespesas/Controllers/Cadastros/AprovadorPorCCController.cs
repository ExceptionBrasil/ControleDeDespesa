using ControleDeDespesas.Controllers.Filters;
using Factorys.Aprovacao;
using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ControleDeDespesas.Controllers.Cadastros
{
    /// <summary>
    /// Controler que representa a amarração dos aprovadores por Centro de Custo
    /// </summary>
    [AutorizacaoFilter]
    public class AprovadorPorCCController : Controller
    {
        private AprovadorPorCCDAO aprovaDAO;
        private CentroDeCustoDAO ccDAO;
        private UsuariosDAO userDAO;
        
        public AprovadorPorCCController(AprovadorPorCCDAO aprovDao, CentroDeCustoDAO cDao, UsuariosDAO uDAO)
        {
            this.aprovaDAO = aprovDao;
            this.ccDAO = cDao;
            this.userDAO = uDAO;
        }

        /// <summary>
        /// Gera o Index do AprovadorPor CC
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(aprovaDAO.ListAll());
        }

        

        //Formulário de insersão de resgistros 
        public ActionResult Create()
        {
            ViewBag.CCLista = new SelectList(
                ccDAO.ListAll(),
                "Id",
                "Descricao"
                );

            ViewBag.UsuariosLista = new SelectList(
                userDAO.ListAll(),
                "Id",
                "Nome"
                );

            ViewBag.SuperiorLista = new SelectList(
                userDAO.ListAll(),
                "Id",
                "Nome"
                );
            
            return View();
        }

        // faz a insersão de registros 
        [HttpPost]
        public JsonResult Create(AprovadorPorCCModelView aprovador)
        {
            

            if (aprovador == null)
            {
                return Json(new { success = false, error="Erro Json vazio ou nulo" });
            }

            try
            {
                aprovaDAO.Incluir(AprovadorFactory.GeraAprovador(aprovador));
                //                return RedirectToAction("Index");
                return Json(new { success = true, error = "" });
            }
            catch
            {
                //return View(aprovador);
                return Json(new { success = false, error = "Não foi possível fazer inserir os dados na base" });
            }
        }

        //formulário de Edição de resgitros
        public ActionResult Edit(int id)
        {
            AprovadorPorCCModelView model = AprovadorFactory.GeraModelView(aprovaDAO.GetById(id));
            return View(model);
        }

        //Edição de resgitros
        [HttpPost]
        public ActionResult Edit(AprovadorPorCCModelView aprovador)
        {
            if (aprovador == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            try
            {

                aprovaDAO.Alterar(AprovadorFactory.GeraAprovador(aprovador));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aprovador);
            }
        }

        // Exclusão 
        public ActionResult Delete(int id)
        {
            //AprovadorPorCCModelView modelo = AprovadorFactory.GeraModelView(aprovaDAO.GetById(id));
            aprovaDAO.Excluir(aprovaDAO.GetById(id));
            return RedirectToAction("Index");
        }

        // POST: AprovadorPorCC/Delete/5
        [HttpPost]
        public ActionResult Delete(AprovadorPorCCModelView aprovador)
        {
            if (aprovador == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            try
            {   
                aprovaDAO.Excluir(AprovadorFactory.GeraAprovador(aprovador));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aprovador);
            }
        }
    }
}
