using ControleDeDespesas.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.DAO
{
    /// <summary>
    /// Classe responsável pelo DAO das despesas
    /// </summary>
    public class DespesasDAO
    {
       
        ISession session;
        /// <summary>
        /// Initializes a new instance of the <see cref="DespesasDAO"/> class.
        /// </summary>
        /// <param name="sessao">The sessao.</param>
        public DespesasDAO (ISession sessao)
        {
            this.session = sessao;
        }

        /// <summary>
        /// Faz a inclusão de uma lista de despesas
        /// </summary>
        /// <param name="despesa">The despesa.</param>
        public void Inclui (IList<Despesas> despesa)
        {
            int ProximoCodigo = NextCod(); 

            ITransaction tran = session.BeginTransaction();

            for (int it = 0; it < despesa.Count; it++)
            {
                despesa[it].CodigoDespesa = ProximoCodigo;
                this.session.Save(despesa[it]);
            }

            tran.Commit();
        }

        /// <summary>
        /// Faz a alteração de uma lista de despeas
        /// </summary>
        /// <param name="despesa">The despesa.</param>
        public void Alterar (IList<Despesas> despesa)
        {
            ITransaction tran = session.BeginTransaction();

            for (int it = 0; it < despesa.Count; it++)
            {                
                this.session.Merge(despesa[it]);
            }

            tran.Commit();
        }

        /// <summary>
        /// Exclui uma lista de Despesa
        /// </summary>
        /// <param name="despesa">The despesa.</param>
        public void Excluir(IList<Despesas> despesa)
        {
            ITransaction tran = session.BeginTransaction();

            for (int it = 0; it < despesa.Count; it++)
            {
                this.session.Delete(despesa[it]);
            }

            tran.Commit();
        }

        /// <summary>
        /// Gets the despesa.
        /// </summary>
        /// <returns></returns>
        public IList<Despesas> GetDespesa()
        {
            var despesas = session.QueryOver<Despesas>()
                                  .List();
            return despesas;
        }


        public IList<Despesas> GetDespesasUnapproved()
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d=> d.DataAprovacao==null)
                                  .List();
            return despesas;
        }


        /// <summary>
        /// Obtem o útimo codigo usado e retorna ele +1
        /// </summary>
        /// <returns>
        /// int
        /// </returns>
        /// <example>
        /// var Codigo = NextCod();                
        /// </example>
        private int NextCod()
        {
            var nextCod = session.QueryOver<Despesas>()
                                 .Select(Projections.Max<Despesas>(x => x.CodigoDespesa))
                                 .SingleOrDefault<int>();
                           
            return nextCod+1;
                                 
        }
        

    }
}