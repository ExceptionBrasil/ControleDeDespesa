using ControleDeDespesas.Controllers.Filters;
using ControleDeDespesas.DAO;
using ControleDeDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeDespesas.Controllers
{
    [AurizacaoFilter]
    public class TiposDespesasController : Controller
    {
        private TiposDeDespesasDAO tiposDAO;

        public TiposDespesasController(TiposDeDespesasDAO tipo)
        {
            this.tiposDAO = tipo;
        }

        // GET: TiposDespesas
        public ActionResult Index()
        {
            return View(tiposDAO.Lista());
        }

        public ActionResult FormIncluir()
        {
            TiposDeDespesas tipo = new TiposDeDespesas();
            return View(tipo);
        }

        
        public ActionResult FormAlterar(int id)
        {
            return View(tiposDAO.GetById(id));
        }


        [HttpPost]
        public ActionResult Incluir(TiposDeDespesas tipo)
        {
            if (ModelState.IsValid)
            {
                tiposDAO.Inclui(tipo);
                return RedirectToAction("Index");
            }
            else
            {
                return View(tipo);
            }
            
        }


        
        public ActionResult Excluir(int id)
        {
            tiposDAO.Excluir(tiposDAO.GetById(id));
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(TiposDeDespesas tipo)
        {
            tiposDAO.Alterar(tipo);
            return RedirectToAction("Index");
        }


    }
}