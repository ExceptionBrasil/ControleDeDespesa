using MeuWebApi2.DAO.Faturamento.Cadastros;
using MeuWebApi2.Model.Faturamento.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MeuWebApi2.Controllers
{
    public class CadastroDeClienteController : ApiController
    {
        private CadastroDeClienteDAO clienteDAO;

        public CadastroDeClienteController(CadastroDeClienteDAO cliDao)
        {
            this.clienteDAO = cliDao;
        }

        // GET: api/CadastroDeCliente
        [ResponseType(typeof(CadastroDeCliente))]
        public IList<CadastroDeCliente> Get()
        {
            var lista = clienteDAO.ListaClientes();

            return lista;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/CadastroDeCliente/5
        [ResponseType(typeof(CadastroDeCliente))]
        //public IHttpActionResult Get(string codigo)
        public string Get(string codigo)
        {
            return "Cliente";
            //return clienteDAO.GetCliente(codigo);
        }

        // POST: api/CadastroDeCliente
        [ResponseType(typeof(CadastroDeCliente))]
        public string Post([FromBody]string value)
        {
            return "Sucesso!";
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
