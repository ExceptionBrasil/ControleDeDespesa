using ControleDeDespesas.Controllers.Filters;
using Persistencia.DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult FrmIncluir()
        {
            TiposDeDespesas tipo = new TiposDeDespesas();
            return View(tipo);
        }

        
        public ActionResult FrmAlterar(int id)
        {
            return View(tiposDAO.GetById(id));
        }


        [HttpPost]
        public ActionResult Incluir(TiposDeDespesas tipo)
        {
            if(tipo == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

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


        /// <summary>
        /// Exclusão dos tipos de despesas
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Excluir(int id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            tiposDAO.Excluir(tiposDAO.GetById(id));
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Alteração dos tipos de despesas
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns></returns>
        public ActionResult Alterar(TiposDeDespesas tipo)
        {
            if (tipo==null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            tiposDAO.Alterar(tipo);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Retorna todos os  tipos em formato Json 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetTipos()
        {
            var tipos = tiposDAO.Lista();

            return Json(tipos,JsonRequestBehavior.AllowGet);
        }


        

    }
}