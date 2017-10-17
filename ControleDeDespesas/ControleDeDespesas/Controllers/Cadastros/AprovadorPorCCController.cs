using ControleDeDespesas.Controllers.Filters;
using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ControleDeDespesas.Controllers.Cadastros
{
    [AurizacaoFilter]
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

        // GET: AprovadorPorCC
        public ActionResult Index()
        {
            return View(aprovaDAO.ListAll());
        }

        

        // GET: AprovadorPorCC/Create
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

        // POST: AprovadorPorCC/Create
        [HttpPost]
        public ActionResult Create(AprovadorPorCCModelView aprovador)
        {
            try
            {
                //aprovaDAO.Incluir(amarracao);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aprovador);
            }
        }

        // GET: AprovadorPorCC/Edit/5
        public ActionResult Edit(int id)
        {
            return View(aprovaDAO.GetById(id));
        }

        // POST: AprovadorPorCC/Edit/5
        [HttpPost]
        public ActionResult Edit(AprovadorPorCC amarracao)
        {
            try
            {

                aprovaDAO.Alterar(amarracao);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(amarracao);
            }
        }

        // GET: AprovadorPorCC/Delete/5
        public ActionResult Delete(int id)
        {

            return View(aprovaDAO.GetById(id));
        }

        // POST: AprovadorPorCC/Delete/5
        [HttpPost]
        public ActionResult Delete(AprovadorPorCC amarracao)
        {
            try
            {
                aprovaDAO.Excluir(amarracao);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(amarracao);
            }
        }
    }
}
