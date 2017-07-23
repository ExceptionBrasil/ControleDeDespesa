using MeuWebAPIRest.DAO.Faturamento.Cadastros;
using Ninject;
using Ninject.Syntax;
using MeuWebAPIRest.Models.Faturamento.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeuWebAPIRest.Controllers.Faturamento.Cadastros
{
    public class CadastroDeClienteController : ApiController
    {
        private CadastroDeClienteDAO clienteDAO;

        private string teste;
        public CadastroDeClienteController(CadastroDeClienteDAO cliDAO)
        {
            this.clienteDAO = cliDAO;

        }

        // GET: api/CadastroDeCliente
        public IEnumerable<string> Get()
        {
        
            return clienteDAO.ListaClientes();
            //return  new string[] { "Cliente1", "Cliente2" };
        }

        // GET: api/CadastroDeCliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CadastroDeCliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CadastroDeCliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CadastroDeCliente/5
        public void Delete(int id)
        {
        }
    }
}
