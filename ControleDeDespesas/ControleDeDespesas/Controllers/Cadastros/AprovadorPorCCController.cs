using Modelos;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ControleDeDespesas.Controllers.Cadastros
{
    public class AprovadorPorCCController : Controller
    {
        private AprovadorPorCCDAO aprovaDAO;
        
        public AprovadorPorCCController(AprovadorPorCCDAO aprovDao)
        {
            this.aprovaDAO = aprovDao;
        }

        // GET: AprovadorPorCC
        public ActionResult Index()
        {

            return View(aprovaDAO.ListAll());
        }

        

        // GET: AprovadorPorCC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AprovadorPorCC/Create
        [HttpPost]
        public ActionResult Create(AprovadorPorCC amarracao)
        {
            try
            {
                aprovaDAO.Incluir(amarracao);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(amarracao);
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
