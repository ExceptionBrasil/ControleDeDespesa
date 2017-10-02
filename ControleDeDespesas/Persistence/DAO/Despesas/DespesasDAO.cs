using Modelos;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistencia.DAO
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
        /// Pega todas as despesas disponíveis no mundo !
        /// </summary>
        /// <returns></returns>
        public IList<Despesas> GetDespesa()
        {
            var despesas = session.QueryOver<Despesas>()
                                  .List();
            return despesas;
        }

        /// <summary>
        /// Retorna todas as despesasv do usuário atual
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public IList<Despesas> GetDespesas(CadastroDeUsuario usuario)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.UsuarioInclusao == usuario)                                  
                                  .List();
            return despesas;
        }

        /// <summary>
        ///  Retorna todas as despesas  usuário atual
        ///  Em forma de paginação 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="indexPage"></param>
        /// <param name="maxElementsByPage"></param>
        /// <param name="maxElements"></param>
        /// <returns>Máximo de elementos</returns>
        public IList<Despesas> GetDespesas(CadastroDeUsuario usuario, int indexPage, int maxElementsByPage, out int maxElements)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.UsuarioInclusao == usuario)
                                  .And(d => d.Id > (indexPage * maxElementsByPage) && d.Id <= ((indexPage * maxElementsByPage) + maxElementsByPage))
                                  .OrderBy(d => d.DataAprovacao).Asc
                                  .List<Despesas>();
                               
                                  
                                 
            
                                  

            maxElements = session.QueryOver<Despesas>()
                                  .Where(d => d.UsuarioInclusao == usuario)
                                  .RowCount();

            return  despesas;
        }

        /// <summary>
        /// Retorna todas as despesas não aprovadas do usuário atual
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public IList<Despesas> GetDespesasUnApproved(CadastroDeUsuario usuario)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d=> d.DataAprovacao==null)
                                  .And(d=> d.UsuarioInclusao==usuario)
                                  .List();
            return despesas;
        }

        /// <summary>
        ///  Retorna todas as despesas não aprovadas do usuário atual
        ///  Em forma de paginação 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="indexPage"></param>
        /// <param name="maxElementsByPage"></param>
        /// <param name="maxElements"></param>
        /// <returns>Máximo de elementos</returns>
        public IList<Despesas> GetDespesasUnApproved( CadastroDeUsuario usuario,int indexPage, int maxElementsByPage, out int maxElements)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.DataAprovacao == null)
                                  .And(d => d.UsuarioInclusao == usuario)
                                  .And(d=> d.Id>(indexPage * maxElementsByPage) && d.Id <= ((indexPage * maxElementsByPage)+maxElementsByPage))
                                  .List();
            
            maxElements = session.QueryOver<Despesas>()
                                  .Where(d => d.DataAprovacao == null)
                                  .And(d => d.UsuarioInclusao == usuario)
                                  .RowCount();

            return despesas;
        }

        /// <summary>
        /// Retorna todas as despesas aprovadas do usuário atual
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public IList<Despesas> GetDespesasApproved(CadastroDeUsuario usuario)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.DataAprovacao != null)
                                  .And(d => d.UsuarioInclusao == usuario)
                                  .List();
            return despesas;
        }




        /// <summary>
        ///  Retorna todas as despesas aprovadas do usuário atual
        ///  Em forma de paginação 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="indexPage"></param>
        /// <param name="maxElementsByPage"></param>
        /// <param name="maxElements"></param>
        /// <returns>Máximo de elementos</returns>
        public IList<Despesas> GetDespesasApproved(CadastroDeUsuario usuario, int indexPage, int maxElementsByPage, out int maxElements)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.DataAprovacao != null)
                                  .And(d => d.UsuarioInclusao == usuario)
                                  .And(d => d.Id > (indexPage * maxElementsByPage) && d.Id <= ((indexPage * maxElementsByPage) + maxElementsByPage))
                                  .List();

            maxElements = session.QueryOver<Despesas>()
                                  .Where(d => d.DataAprovacao != null)
                                  .And(d => d.UsuarioInclusao == usuario)
                                  .RowCount();

            return despesas;
        }

       


        /// <summary>
        /// retorna a lista de Despesas por código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public IList<Despesas> GetDespesaByCodigo(int codigo)
        {
            var despesas = session.QueryOver<Despesas>()
                                  .Where(d => d.CodigoDespesa == codigo)
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