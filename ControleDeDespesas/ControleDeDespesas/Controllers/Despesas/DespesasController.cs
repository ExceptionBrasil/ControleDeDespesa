using ControleDeDespesas.Controllers.Filters;
using Persistencia.DAO;
using Modelos;
using Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Factorys;
using BuildMenu;
using System.Net;
using Interfaces;
using X.PagedList;

namespace ControleDeDespesas.Controllers
{
    
    [AutorizacaoFilter]   
    public class DespesasController : Controller, ISetMenu
    {
        private UsuariosDAO usuarioDAO;
        private TiposDeDespesasDAO tiposDAO;
        private DespesasDAO despesasDAO;        
      

        public DespesasController(UsuariosDAO userDAO, TiposDeDespesasDAO tpDAO, DespesasDAO depDAO)
        {
            this.usuarioDAO = userDAO;
            this.tiposDAO = tpDAO;
            this.despesasDAO = depDAO;            
       

            //Carrega os Menus desse controller
            BuildMenu();

        }

        /// <summary>
        /// Menus que vão ser carregados desses controller 
        /// </summary>
        public void BuildMenu()
        {

            MakeMenu.Add("Despesas", "FrmIncluir", "Despesas", "Nova Despesa",Role.User);
            MakeMenu.Add("Usuarios", "Index", "Despesas", "Cadastro de Usuários", Role.SuperUser);
            MakeMenu.Add("CentroDeCusto", "Index", "Despesas", "Cadastro de Centro De Custo", Role.SuperUser);
            MakeMenu.Add("TiposDespesas", "Index", "Despesas", "Cadastro de Tipos Despesas", Role.SuperUser);
            MakeMenu.Add("Aprovacao", "Index", "Despesas", "Aprovação", Role.Approver);
            

        }

        /// <summary>
        /// Gera a Home Page das Despesas
        /// </summary>
        /// <returns></returns>        
        [Menu("Despesas", "Index",  "Despesas", "Home")]
        public ActionResult Index(int? pagina)
        {
            //Tratar aqui uma mensagem bonitinha para o usuário que sua sessão expirou.
            if (!WebSecurity.Initialized)
            {
                //RedirectToAction("Logout", "Home");
                
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }

            //Recupera a session para o cadasrtro de usuário
            CadastroDeUsuario usuario = (CadastroDeUsuario)Session["Usuario"];

            int paginaAtual = (pagina ?? 1) - 1;
            int tamanhoDaPagina = 10; //Registros por página
            int totalDeRegistros;

            //Monta o modelo das despesas
            var despesas = despesasDAO.GetDespesas(usuario, paginaAtual, tamanhoDaPagina, out totalDeRegistros);

            //Monta a paginacao
            var umaPaginaDeDespesas = new StaticPagedList<Despesas>(despesas, paginaAtual + 1, tamanhoDaPagina, totalDeRegistros);
            

            ViewBag.DespesasCount = totalDeRegistros;
            ViewBag.UmaPaginaDeDespesas = umaPaginaDeDespesas;

            return View(despesas);
        }


        /// <summary>
        /// Formulário de inclusão.
        /// </summary>
        /// <returns></returns>        
        public ActionResult FrmIncluir()
        {
            ViewBag.TiposDeDespesa = tiposDAO.Lista();
            ViewBag.ListTiposDespesas = new SelectList
                (
                    tiposDAO.Lista(),
                    "Id",
                    "Descricao"
                );
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
                return Json(new { success = false,menssage = "Objeto Json vazio" });

            }
            
            //Gera a lista de Despesas com base na lista de Json 
            List<Despesas> despesas =  DespesasJsonToDespesas.GeraLista(despesasJson, (CadastroDeUsuario)Session["Usuario"], (DateTime)Session["dataEstatica"]);
            
                       
            //Faz a inclusão da Despesa
            despesasDAO.Inclui(despesas);



            //Retorna sucesso após inclusão
            return Json(new { success = true });
        }

        public ActionResult Visualizar(int id)
        {
            var modelo =  despesasDAO.GetDespesaByCodigo(id);

            return PartialView(modelo);
        }

      
       
    }
}