using ControleDeDespesas.Controllers.Filters;
using Persistence.DAO;
using Persistence.Factorys;
using Modelos;
using Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using X.PagedList;

namespace ControleDeDespesas.Controllers
{
    
    [AurizacaoFilter]
    public class DespesasController : Controller
    {
        private UsuariosDAO usuarioDAO;
        private TiposDeDespesasDAO tiposDAO;
        private DespesasDAO despesasDAO;
        

        public DespesasController(UsuariosDAO userDAO, TiposDeDespesasDAO tpDAO, DespesasDAO depDao)
        {
            this.usuarioDAO = userDAO;
            this.tiposDAO = tpDAO;
            this.despesasDAO = depDao;
        }

        /// <summary>
        /// Gera a Home Page das Despesas
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? pagina)
        {
            int paginaAtual = (pagina ?? 1) - 1;
            int tamanhoDaPagina = 10; //Registros por página
            int totalDeRegistros;


            //Se a senha expirou retorno ele para home
            if(WebSecurity.CurrentUserId == null)
            {
                RedirectToAction("Logout", "Home");
            }

            CadastroDeUsuario usuario = usuarioDAO.GetById(WebSecurity.CurrentUserId);
            Session["Usuario"] = usuario;
            ViewBag.IsAdmin = usuario.IsAdmin;
            ViewBag.IsAprovador = usuario.IsAprovador;

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

    }
}