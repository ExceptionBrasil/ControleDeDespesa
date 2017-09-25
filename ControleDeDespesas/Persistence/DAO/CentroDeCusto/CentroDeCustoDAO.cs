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

        public IList<CentroDeCusto> GetByCodigo(string codigo)
        {
            var list = session.QueryOver<CentroDeCusto>()
                              .Where(c => c.Codigo == codigo)
                              .List();

            return list;
        }

        public CentroDeCusto GetById(int id)
        {
            var list = session.QueryOver<CentroDeCusto>()
                              .Where(c => c.Id == id)
                              .SingleOrDefault<CentroDeCusto>();

            return list;
        }

        public IList<CentroDeCusto> ListAll()
        {
            var list = session.QueryOver<CentroDeCusto>()                              
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
