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
using X.PagedList;
using Factorys;
using BuildMenu;

namespace ControleDeDespesas.Controllers
{
    
    [AurizacaoFilter]
    
    public class DespesasController : Controller
    {
        private UsuariosDAO usuarioDAO;
        private TiposDeDespesasDAO tiposDAO;
        private DespesasDAO despesasDAO;
        private AprovadorPorCCDAO aprovDAO;
        

        public DespesasController(UsuariosDAO userDAO, TiposDeDespesasDAO tpDAO, DespesasDAO depDao, AprovadorPorCCDAO aprov)
        {
            this.usuarioDAO = userDAO;
            this.tiposDAO = tpDAO;
            this.despesasDAO = depDao;
            this.aprovDAO = aprov;

            //Carrega os Menus desse controller
            BuildMenus();

        }

        /// <summary>
        /// Menus que v~ao ser carregados desses controller 
        /// </summary>
        private void BuildMenus()
        {

            MakeMenu.Add("Despesas", "FrmIncluir", "Despesas", "Nova Despesa","All");
            MakeMenu.Add("Usuarios", "Index", "Despesas", "Cadastro de Usuários", "Admin");
            MakeMenu.Add("CentroDeCusto", "Index", "Despesas", "Cadastro de Centro De Custo", "SuperUser");
            MakeMenu.Add("TiposDespesas", "Index", "Despesas", "Cadastro de Tipos Despesas", "SuperUser");
            MakeMenu.Add("AprovadorPorCC", "Index", "Despesas", "Aprovador por CC", "SuperUser");

        }

        /// <summary>
        /// Gera a Home Page das Despesas
        /// </summary>
        /// <returns></returns>        
        [Menu("Despesas", "Index",  "Despesas", "Home")]
        public ActionResult Index(int? pagina)
        {
           
            int paginaAtual = (pagina ?? 1) - 1;
            int tamanhoDaPagina = 10; //Registros por página
            int totalDeRegistros;


            //Tratar aqui uma mensagem bonitinha para o usuário que sua sessão expirou.
            if (!WebSecurity.Initialized)
            {
                RedirectToAction("Logout", "Home");
            }

            //Se a senha expirou retorno ele para home
            if(WebSecurity.CurrentUserId == null)
            {
                RedirectToAction("Logout", "Home");
            }

            CadastroDeUsuario usuario = usuarioDAO.GetById(WebSecurity.CurrentUserId);
            Session["Usuario"] = usuario;
            ViewBag.IsAdmin = usuario.IsAdmin;
            ViewBag.UnApprovedRDV = null;

            //Verifica se o se o usuário autenticado é também um aprovador e retorna seus centros custos
            IList<AprovadorPorCC> CCAutorizados =  aprovDAO.ListByUsuario(usuario);
            if (CCAutorizados.Count > 0)
            {
                //Recupera a Lista de RDVs pendentes a aprovação 
                ViewBag.UnApprovedRDV =  despesasDAO.GetDespesasUnApproved(CCAutorizados);
            }


            //Retorna a quantidade de resgistros para a página atual
            var despesas = despesasDAO.GetDespesas(usuario, paginaAtual, tamanhoDaPagina, out totalDeRegistros);
                            

            //Monta a paginacao
            var umaPaginaDeDespesas = new StaticPagedList<Despesas>(despesas, paginaAtual + 1, tamanhoDaPagina, totalDeRegistros);
            //var model = despesasDAO.GetDespesasUnApproved(usuario);

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
           

            List<Despesas> despesas =  DespesasJsonToDespesas.GeraLista(despesasJson);

            
            //Completa algumas informações antes de gravar
            foreach (var it in despesas)
            {
                it.UsuarioInclusao = (CadastroDeUsuario) Session["Usuario"];  
                it.CentroDeCusto = it.UsuarioInclusao.CentroDeCusto;
            }

            despesasDAO.Inclui(despesas);

            return Json(new { success = true });
        }

        public ActionResult Visualizar(int id)
        {
            var modelo =  despesasDAO.GetDespesaByCodigo(id);

            return PartialView(modelo);
        }

        /// <summary>
        /// Realiza a aprovação de uma despesa 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Aprovar(int id)
        {
            if (!despesasDAO.AprovarDespesa(id, usuarioDAO.GetById(WebSecurity.CurrentUserId)))
            {
                return Json(new { success = false, error = "Erro ao aprovar a Despesa" });
            }

            return Json(new { success = true, error = "Erro ao aprovar a Despesa" });
        }

    }
}