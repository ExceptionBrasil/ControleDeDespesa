using ControleDeDespesas.Controllers.Filters;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persistencia.DAO;

namespace ControleDeDespesas.Controllers.Cadastros
{
    [AurizacaoFilter]
    public class CentroDeCustoController : Controller
    {
        private CentroDeCustoDAO ccDAO;
        

        public CentroDeCustoController(CentroDeCustoDAO cDao)
        {
            this.ccDAO = cDao;
        }

        public ActionResult Index()
        {
          

            var modelo = ccDAO.ListAll();
            return View(modelo);
        }

        public ActionResult Incluir()
        {
            return View();
        }

        public ActionResult Alterar()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Incluir(CentroDeCusto custo)
        {
            ccDAO.Alterar(custo);
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {

            ccDAO.Excluir(ccDAO.GetById(id));
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Alterar(CentroDeCusto custo)
        {
            ccDAO.Alterar(custo);
            return RedirectToAction("Index");
        }
    }
}