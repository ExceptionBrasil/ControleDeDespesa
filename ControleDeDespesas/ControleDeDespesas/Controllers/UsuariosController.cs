using ControleDeDespesas.Controllers.Filters;
using Persistence.DAO;
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
                return View("Novo",usuario);
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
            
            
            return RedirectToAction("Index");
        }
    }
}