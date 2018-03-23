using Persistencia.DAO;
using Modelos.ViewModels;
using System.Web.Mvc;
using WebMatrix.WebData;
using Modelos;
using Factorys.Helpers;
using Factorys.Tools;

using PdfControl;
using System.Net;

namespace ControleDeDespesas.Controllers
{

    public class HomeController : Controller
    {
        private UsuariosDAO usuarioDAO; 

        public HomeController(UsuariosDAO userDao)
        {
            this.usuarioDAO = userDao;

            if (!WebSecurity.Initialized)
            {  
                
                WebSecurity.InitializeDatabaseConnection(ConfigureHelper.Key("connection.connection_string_name")
                                                        , "CadastroDeUsuario", "Id", "Login", true);

                

                
            }
        }


        /// <summary>
        /// Home
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            var usuario = (CadastroDeUsuario)Session["Usuario"];
            
            if( usuario!= null)
            {
                return RedirectToAction("Index", "Despesas");
            }

         

            return View();
        }



        /// <summary>
        /// Metodo responsável por fazer a atutenticação do usuário 
        /// </summary>
        /// <param name="autenticacao">The autenticacao.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Autentica(Autenticacao autenticacao)
        {
            if (autenticacao == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    
            }

            if (WebSecurity.Login(autenticacao.Login, autenticacao.Senha))
            {
                //Cria a Sessão de página
                CadastroDeUsuario usuario = usuarioDAO.GetById(WebSecurity.GetUserId(autenticacao.Login));
                Session["Usuario"] = usuario;
                Session.Timeout = 15;

                //no primeiro acesso cria o diretorio de imagens do usuário
                DiretorioFactory.Cria(usuario.Id,Server.MapPath("~/Content/Images/Users/"));


                //Faz o retorno para o Ajax 
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            Session.RemoveAll();            
            WebSecurity.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}