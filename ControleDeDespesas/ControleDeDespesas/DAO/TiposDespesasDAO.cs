using ControleDeDespesas.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.DAO
{
    public class TiposDespesasDAO
    {
        private ISession session;

        public TiposDespesasDAO (ISession sessao)
        {
            this.session = sessao;
        }

        public void Adiciona (TiposDespesas despesa)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(despesa);
            transaction.Commit();
        }

        public void Exclui (TiposDespesas despesa)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(despesa);
            transaction.Commit();
        }

        public void Altera(TiposDespesas despesa)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Merge(despesa);
            transaction.Commit();
        }


        public IList<TiposDespesas> Lista()
        {
            var listaTipoDespesas = session.QueryOver<TiposDespesas>()
                                                    .List();

            return listaTipoDespesas;
        }


        public TiposDespesas GetById(int id)
        {
            var tipoDespesa = session.QueryOver<TiposDespesas>()
                                      .Where(t => t.Id == id)
                                      .SingleOrDefault();
            return tipoDespesa;
        }


    }
}