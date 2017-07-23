using MeuWebApi2.DAO.Faturamento.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuWebApi2.Controllers
{
    public class HomeController : Controller
    {
        private CadastroDeClienteDAO clienteDAO;

        public HomeController (CadastroDeClienteDAO cliDAO)
        {
            this.clienteDAO = cliDAO;
        }

        // GET: Home
        public ActionResult Index()
        {
            clienteDAO.ListaClientes();
            return View();
        }

    }
}