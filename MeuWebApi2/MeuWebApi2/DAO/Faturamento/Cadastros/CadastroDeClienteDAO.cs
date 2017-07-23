using MeuWebApi2.Model.Faturamento.Cadastros;
using NHibernate;
using System.Collections.Generic;
using System.Web.Http;

namespace MeuWebApi2.DAO.Faturamento.Cadastros
{
    public class CadastroDeClienteDAO
    {

        private ISession session;

        public CadastroDeClienteDAO(ISession sessao)
        {
            this.session = sessao;
        }

        public IList<CadastroDeCliente> ListaClientes()
        {
            var lista = session.QueryOver<CadastroDeCliente>().List();
            return lista;
        }
        /*
        public IHttpActionResult GetClienteByCodigo(string codigo)
        {
            var cliente = session.QueryOver<CadastroDeCliente>()
                                 .Where(c => c.Codigo == codigo)
                                 .SingleOrDefault();

            return NotFound();
            

           
        }*/
    }
}