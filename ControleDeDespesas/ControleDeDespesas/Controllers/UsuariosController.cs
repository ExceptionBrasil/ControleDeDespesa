using ControleDeDespesas.DAO;
using ControleDeDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeDespesas.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuariosDAO usuarioDAO;

        public UsuariosController (UsuariosDAO usarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Adicionar(CadastroDeUsuario usuario)
        {

            return View();
        }
    }
}