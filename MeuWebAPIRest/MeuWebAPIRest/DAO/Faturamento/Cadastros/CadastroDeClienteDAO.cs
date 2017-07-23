using MeuWebAPIRest.Models.Faturamento.Cadastros;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuWebAPIRest.DAO.Faturamento.Cadastros
{
    public class CadastroDeClienteDAO
    {
        private ISession session;

        public CadastroDeClienteDAO(ISession sessao)
        {
            this.session = sessao;
        }

        public IEnumerable<string> ListaClientes()
        {
            var lista = session.QueryOver<CadastroDeCliente>()
                                .List();
            return new string[] { "Daniel" };//lista;
        }
    }
}