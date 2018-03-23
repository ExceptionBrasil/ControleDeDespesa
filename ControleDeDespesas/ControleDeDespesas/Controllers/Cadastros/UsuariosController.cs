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
using BuildMenu;
using Interfaces;
using ControleDeDespesas.Security;
using Factorys.Mail;

namespace ControleDeDespesas.Controllers
{
    
    public class UsuariosController : Controller, ISetMenu
    {
        private UsuariosDAO usuarioDAO;
        private CentroDeCustoDAO ccDAO;

        public UsuariosController(UsuariosDAO user, CentroDeCustoDAO cc)
        {
            this.usuarioDAO = user;
            this.ccDAO = cc;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("local", "CadastroDeUsuario", "Id", "Login", true);
            }

            BuildMenu();
        }

        /// <summary>
        /// Construção dos Menus
        /// </summary>
        public void BuildMenu()
        {
            MakeMenu.Add("Usuarios", "Adicionar", "Usuarios", "Novo Cadastro", Role.User);
            MakeMenu.Add("Despesas", "Index", "Usuarios", "Home", Role.User);
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [AutorizacaoFilter]
        public ActionResult Index() { return View(usuarioDAO.ListAll()); }




        /// <summary>
        /// Formulário de inclusão de usuário
        /// </summary>
        /// <returns></returns>
        [AutorizacaoFilter]
        public ActionResult Adicionar()
        {
            ViewBag.CentroDeCusto = new SelectList(
              ccDAO.ListAll(),
              "Codigo",
              "DescricaoExtendida"
              );
            ViewBag.Role = new SelectList(
                       new RoleDAO().ListRole,
                       "Role",
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
        [AutorizacaoFilter]
        [HttpPost]
        public ActionResult Adicionar(UsuarioModelView modelUser)
        {
            //Valida se há dados paracontinuar
            if (modelUser == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

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
                    int? cc = null;
                    if (usuario.CentroDeCusto != null)
                    {
                        cc = usuario.CentroDeCusto.Id;
                    }
                    //Cria o usuário 
                    WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Senha, new
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        IsAdmin = usuario.IsAdmin,
                        Cpf = usuario.Cpf,
                        CentroDeCusto_id = cc
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
                return View(modelUser);
            }
        }

        /// <summary>
        /// Exclui um usuário do banco de dados 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AutorizacaoFilter]
        public ActionResult Excluir(int id)
        {
            try
            {
                Membership.DeleteUser(usuarioDAO.GetById(id).Login, true);
            } catch (Exception ex)
            {
                return View("EntidadeEmUso");
            }
            return RedirectToAction("Index");
        }

        [AutorizacaoFilter]
        public ActionResult EntidadeEmUso() {return View(); }

        /// <summary>
        /// Formulário de Alteração
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AutorizacaoFilter]
        public ActionResult Alterar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            ViewBag.CentroDeCusto = new SelectList(
               ccDAO.ListAll(),
               "Codigo",
               "Descricao"
               );
            ViewBag.Role = new SelectList(
                    new RoleDAO().ListRole,
                    "Role",
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
        [AutorizacaoFilter]
        [HttpPost]
        public ActionResult Alterar(FormCollection form,UsuarioModelView modelUser)
        {

            //Valida se há dados para continuar
            if (modelUser == null)
            {
                return new HttpStatusCodeResult(
                        HttpStatusCode.BadRequest);
            }

            CadastroDeUsuario usuario = UsuarioFactory.GeraUsuario(modelUser);

            
            MembershipUser user = Membership.GetUser(usuario.Login);
            if (ModelState.IsValid)
            {
                try
                {
                    //SecurityProvider securi = new SecurityProvider(usuarioDAO);
                    //securi.ChangePassword(usuario.Id, "", usuario.Senha);                   
                    user.ChangePassword(usuarioDAO.GetById(usuario.Id).Senha, usuario.Senha);
                    usuarioDAO.Altera(usuario);
               
                    
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

        /// <summary>
        /// Formulário de recuperação de senha 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
            var model = new RecoverPasswordModelView();
            return View(model);
        }


        /// <summary>
        /// Recupera a senha, retornando um senha aleatória e redireciona para uma página de senha recuperada
        /// </summary>
        /// <param name="recover">The recover.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult RecoverPasswordResult(RecoverPasswordModelView recover)
        {
            if (recover == null)
            {
                return View("RecoverPassword", recover);
            }
                        
            CadastroDeUsuario usuario = usuarioDAO.GetByEmail(recover.Email);
            if(usuario == null)
            {
                return View("RecoverPassword", recover);
            }

            MembershipUser user = Membership.GetUser(usuario.Login);
            string newToken = Membership.GeneratePassword(12, 1);

            //Tenta realizar a aletração da senha do usuário
            try
            {
                                
                //user.ChangePassword(usuario.Senha, newPassword);

                //usuario.Senha = newPassword;
                //usuarioDAO.Altera(usuario);

                Mail email = new Mail(usuario.Email, "workflow@finiguloseimas.com.br", "Recuperação de Login", "Token " + usuario.Senha);
                email.Send();

            }catch(ArgumentException ex)
            {
                return View("EntidadeEmUso");
            }

            return View();
        }

    }
}