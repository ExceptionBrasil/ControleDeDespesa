using ControleDeDespesas.Controllers.Filters;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persistencia.DAO;
using BuildMenu;

namespace ControleDeDespesas.Controllers.Cadastros
{
    [AurizacaoFilter]
    public class CentroDeCustoController : Controller
    {
        private CentroDeCustoDAO ccDAO;
        private UsuariosDAO usuariosDAO;

        public CentroDeCustoController(CentroDeCustoDAO cDao, UsuariosDAO users)
        {
            this.ccDAO = cDao;
            this.usuariosDAO = users;

            BuildMenu();
        }


        private void BuildMenu()
        {
            MakeMenu.Add("Despesas", "Index", "CentroDeCusto", "Home", Role.SuperUser);
            MakeMenu.Add("CentroDeCusto", "Incluir", "CentroDeCusto", "Novo Centro de Custo", Role.SuperUser);
        }

        [Menu("CentroDeCusto","Index", "CentroDeCusto","Cadastro de Centro de Custo")]
        public ActionResult Index()
        {
          

            var modelo = ccDAO.ListAll();
            return View(modelo);
        }

        
        public ActionResult Alterar(int id)
        {

            ViewBag.Aprovador = new SelectList
                (
                    usuariosDAO.ListAll(),
                    "Id",
                    "Nome"
                );
            return View(ccDAO.GetById(id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Alterar(FormCollection form,CentroDeCusto custo)
        {

            custo.Aprovador = usuariosDAO.GetById(Convert.ToInt32(form["Aprovador"]));           
            ccDAO.Alterar(custo);
            return RedirectToAction("Index");
        }

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


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Incluir(FormCollection form,CentroDeCusto custo)
        {
            custo.Aprovador = usuariosDAO.GetById(Convert.ToInt32(form["Id"]));
            ccDAO.Incluir(custo);
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {

            ccDAO.Excluir(ccDAO.GetById(id));
            return RedirectToAction("Index");
        }

        
    }
}