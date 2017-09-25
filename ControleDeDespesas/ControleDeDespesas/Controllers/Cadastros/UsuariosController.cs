using ControleDeDespesas.Controllers.Filters;
using Persistencia.DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ControleDeDespesas.Controllers
{
    [AurizacaoFilter]
    public class UsuariosController : Controller
    {
        private UsuariosDAO usuarioDAO;

        public UsuariosController (UsuariosDAO user)
        {
            this.usuarioDAO = user;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("local", "CadastroDeUsuario", "Id", "Login", true);
            }
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var modelo = usuarioDAO.GetAll();
            return View(modelo);
        }
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult FrmAlterar(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            return View(usuarioDAO.GetById(id));
        }

        [HttpPost]
        public ActionResult Adicionar(CadastroDeUsuario usuario)
        {

            if(usuario==null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {                
                try
                {
                    WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Senha, new {                                                         
                                                                                         Nome = usuario.Nome                                                       
                                                                                        ,Email= usuario.Email
                                                                                        ,IsAdmin = usuario.IsAdmin
                                                                                        ,Cpf = usuario.Cpf
                                                                                        ,CentroDeCusto = usuario.CentroDeCusto
                                                                                        }
                                                        , false);
                    
                    
                }catch(MembershipCreateUserException ex)
                {
                    return View(usuario);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }         
        }

        /// <summary>
        /// Exclui um usuário do banco de dados 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Excluir (int id)
        {            
            Membership.DeleteUser(usuarioDAO.GetById(id).Login);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Altera um usuário específico 
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Alterar (CadastroDeUsuario usuario)
        {

            MembershipUser user = Membership.GetUser(usuario.Login);
            if (ModelState.IsValid)
            {
                try
                {
                    Membership.DeleteUser(usuario.Login);
                     WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Senha, new {                                                         
                                                                                         Nome = usuario.Nome                                                       
                                                                                        ,Email= usuario.Email
                                                                                        ,IsAdmin = usuario.IsAdmin
                                                                                        ,Cpf = usuario.Cpf
                                                                                        ,CentroDeCusto = usuario.CentroDeCusto
                                                                                        }
                                                        , false);
 
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Alterar_Usuario", "Erro ao tentar mudar esse usuário " + ex.Message);
                    return View("FrmAlterar", usuario);
                }
               
            }
            else
            {
                return View("FrmAlterar",usuario);
            }


            return RedirectToAction("Index");
        }
    }
}