using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAO
{
    class AprovadorPorCCDAO
    {
        private ISession session;

        public AprovadorPorCCDAO (ISession sessao)
        {
            this.session = sessao;
        }

        public IList<AprovadorPorCC> ListAll()
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .List();

            return list;
        }

        public IList<AprovadorPorCC> ListByUsuario(CadastroDeUsuario usuario)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x=> x.Usuario ==usuario)
                              .List();

            return list;
        }

        public IList<AprovadorPorCC> ListByCC(CentroDeCusto custo)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x=> x.CC == custo)
                              .List();

            return list;
        }

        public AprovadorPorCC GetById(int id)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x => x.Id == id)
                              .SingleOrDefault();

            return list;
        }



        public void Incluir(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(amarracao);
            tran.Commit();
        }

        public void Alterar(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(amarracao);
            tran.Commit();
        }

        public void Excluir(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(amarracao);
            tran.Commit();
        }

    }
}
