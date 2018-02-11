using ControleDeDespesas.Controllers.Filters;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persistencia.DAO;
using BuildMenu;
using Interfaces;
using Modelos.ViewModels;
using Factorys;

namespace ControleDeDespesas.Controllers.Cadastros
{
    [AutorizacaoFilter]
    public class CentroDeCustoController : Controller, ISetMenu
    {
        private CentroDeCustoDAO ccDAO;
        private UsuariosDAO usuariosDAO;

        public CentroDeCustoController(CentroDeCustoDAO cDao, UsuariosDAO users)
        {
            this.ccDAO = cDao;
            this.usuariosDAO = users;

            BuildMenu();
        }

        /// <summary>
        /// Faz a construção dos Menus
        /// </summary>
        public void BuildMenu()
        {
            MakeMenu.Add("Despesas", "Index", "CentroDeCusto", "Home", Role.SuperUser);
            MakeMenu.Add("CentroDeCusto", "Incluir", "CentroDeCusto", "Novo Centro de Custo", Role.SuperUser);
        }

        
        /// <summary>
        /// Página principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
          

            var modelo = ccDAO.ListAll();
            return View(modelo);
        }

        /// <summary>
        /// Form de alteração 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Alterar(int id)
        {

            ViewBag.Aprovador = new SelectList
                (
                    usuariosDAO.ListAll(),
                    "Id",
                    "Nome"
                );
            var model = CentroDeCustoFactory.GetModelView(ccDAO.GetById(id));

            return View(model);
        }

        /// <summary>
        /// Alterção do registro
        /// </summary>
        /// <param name="form"></param>
        /// <param name="custo"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Alterar(/*FormCollection form,*/ CentroDeCustoModelView custo)
        {
            
            ccDAO.Alterar(CentroDeCustoFactory.GetModel(custo));
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Form de inclusão de Centro de Custo
        /// </summary>
        /// <returns></returns>
        public ActionResult Incluir()
        {
            ViewBag.Aprovador =  new SelectList
                (
                    usuariosDAO.ListAll(),
                    "Id",
                    "Nome"
                );
           
            return View();
        }

        /// <summary>
        /// Persiste o Centro de Custo no banco de dados
        /// </summary>
        /// <param name="ccModel">The cc model.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Incluir(CentroDeCustoModelView ccModel)
        {
            
            if(!ModelState.IsValid)
            {
                ViewBag.Aprovador = new SelectList
                  (
                      usuariosDAO.ListAll(),
                      "Id",
                      "Nome"
                  );
                return View(ccModel);
            }

            ccDAO.Incluir(CentroDeCustoFactory.GetModel(ccModel));
            return RedirectToAction("Index");


            //return View("Incluir",ccModel);
        }

        public ActionResult Excluir(int id)
        {

            if (!ccDAO.Excluir(ccDAO.GetById(id)))
            {
                return RedirectToAction("ExcluirErrorPage");
            }
            return RedirectToAction("Index");
        }

        public ActionResult ExcluirErrorPage()
        {
            return View();
        }
    }
}