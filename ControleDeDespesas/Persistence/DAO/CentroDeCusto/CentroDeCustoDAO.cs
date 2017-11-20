using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAO
{
    public class CentroDeCustoDAO
    {
        private ISession session;

        public CentroDeCustoDAO (ISession sessao)
        {
            this.session = sessao;
        }


        /// <summary>
        /// Retorna um Centro de Custo pelo seu código
        /// </summary>
        /// <param name="codigo">The codigo.</param>
        /// <returns></returns>
        public IList<CentroDeCusto> GetByCodigo(string codigo)
        {
            var list = session.QueryOver<CentroDeCusto>()
                              .Where(c => c.Codigo == codigo)
                              .List();

            return list;
        }


        /// <summary>
        /// Retona um Centro de Custo pelo Id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CentroDeCusto GetById(int id)
        {
            var list = session.QueryOver<CentroDeCusto>()
                              .Where(c => c.Id == id)
                              .SingleOrDefault<CentroDeCusto>();

            return list;
        }

        /// <summary>
        /// Lista todos os centros de custos
        /// </summary>
        /// <returns></returns>
        public IList<CentroDeCusto> ListAll()
        {
            var list = session.QueryOver<CentroDeCusto>()                              
                              .List();

            return list;
        }

        /// <summary>
        /// Obtem os centros de custo pelo aprovador
        /// </summary>
        /// <param name="aprovador">The aprovador.</param>
        /// <returns></returns>
        public IList<CentroDeCusto> GetByAprovador(CadastroDeUsuario aprovador)
        {
            var list = session.QueryOver<CentroDeCusto>()
                              .Where(c => c.Aprovador == aprovador)
                              .List();
            return list;
        }

        public void Incluir(CentroDeCusto cc)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(cc);
            tran.Commit();
        }

        public void Excluir(CentroDeCusto cc)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(cc);
            tran.Commit();
        }

        public void Alterar(CentroDeCusto cc)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(cc);
            tran.Commit();
        }

    }
}
