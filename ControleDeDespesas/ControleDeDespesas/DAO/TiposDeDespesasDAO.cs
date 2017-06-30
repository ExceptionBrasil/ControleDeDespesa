using ControleDeDespesas.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.DAO
{
    public class TiposDeDespesasDAO
    {
        private ISession session;

        public TiposDeDespesasDAO(ISession sessao)
        {
            this.session = sessao;
        }


       public void Inclui (TiposDeDespesas tipo)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(tipo);
            transacao.Commit();

        }

        public void Excluir(TiposDeDespesas tipo)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(tipo);
            transacao.Commit();

        }


        public void Alterar(TiposDeDespesas tipo)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Merge(tipo);
            transacao.Commit();
        }


        public IList<TiposDeDespesas> Lista()
        {
            var lista = session.QueryOver<TiposDeDespesas>()
                                .List();

            return lista;

        }

        public TiposDeDespesas GetById(int id)
        {
            var tipo = session.QueryOver<TiposDeDespesas>()
                              .Where(t => t.Id == id)
                              .SingleOrDefault();
            return tipo;
        }

    }
}