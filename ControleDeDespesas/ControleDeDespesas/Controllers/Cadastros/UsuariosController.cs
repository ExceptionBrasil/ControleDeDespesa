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
using Modelos.ViewModels;
using Factorys;

namespace ControleDeDespesas.Controllers
{
    [AurizacaoFilter]
    public class UsuariosController : Controller
    {
        private UsuariosDAO usuarioDAO;
        private CentroDeCustoDAO ccDAO;

        public UsuariosController (UsuariosDAO user, CentroDeCustoDAO cc )
        {
            this.usuarioDAO = user;
            this.ccDAO = cc;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("local", "CadastroDeUsuario", "Id", "Login", true);
            }
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(){ return View(usuarioDAO.ListAll());}




        /// <summary>
        /// Formulário de inclusão de usuário
        /// </summary>
        /// <returns></returns>
        public ActionResult Adicionar()
        {
            ViewBag.ListCentroDeCusto = new SelectList(
                ccDAO.ListAll(),
                "Id",
                "Descricao"
                );
            return View();
        }


        /// <summary>
        /// Realiza a adição do usuário na base
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="modelUser">The model user.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Adicionar(FormCollection form, UsuarioModelView modelUser)
        {
            //Valida se há dados paracontinuar
            if (modelUser == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            //Valida se preeche o Centro de Custo
            if (String.IsNullOrEmpty(form["ListCentroDeCusto"]))
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);

            }

            modelUser.CentroDeCusto = Convert.ToInt32(form["ListCentroDeCusto"]);
            CadastroDeUsuario usuario = UsuarioFactory.GeraUsuario(modelUser);

            if (usuario == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }


            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Senha, new
                    {
                        Nome = usuario.Nome   ,
                        Email = usuario.Email ,
                        IsAdmin = usuario.IsAdmin,
                        Cpf = usuario.Cpf,                     
                        CentroDeCusto_id = usuario.CentroDeCusto.Id
                    }
                                                        , false);




                }
                catch (MembershipCreateUserException ex)
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
        /// Formulário de Alteração
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Alterar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            ViewBag.ListCentroDeCusto = new SelectList(
               ccDAO.ListAll(),
               "Id",
               "Descricao"
               );

            UsuarioModelView model = UsuarioFactory.GetModelView(usuarioDAO.GetById(id));

            return View(model);
        }

        /// <summary>
        /// Altera um usuário específico 
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Alterar(FormCollection form,UsuarioModelView modelUser)
        {

            //Valida se há dados paracontinuar
            if (modelUser == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            //Valida se preeche o Centro de Custo
            if (String.IsNullOrEmpty(form["ListCentroDeCusto"]))
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);

            }


            modelUser.CentroDeCusto = Convert.ToInt32(form["ListCentroDeCusto"]);
            CadastroDeUsuario usuario = UsuarioFactory.GeraUsuario(modelUser);

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
                    return View("Alterar", usuario);
                }
               
            }
            else
            {
                return View("Alterar",usuario);
            }

    
            return RedirectToAction("Index");
        }
    }
}