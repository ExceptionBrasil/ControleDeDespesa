using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAO
{
    public class AprovadorPorCCDAO
    {
        private ISession session;

        public AprovadorPorCCDAO (ISession sessao)
        {
            this.session = sessao;
        }

        /// <summary>
        /// Lista todos os aprovadores
        /// </summary>
        /// <returns></returns>
        public IList<AprovadorPorCC> ListAll()
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .List();

            return list;
        }

        /// <summary>
        /// Lista todos os Centro de Custos que um usuário pode aprovar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public IList<AprovadorPorCC> ListByUsuario(CadastroDeUsuario usuario)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x=> x.Usuario ==usuario)
                              .List();

            return list;
        }

        /// <summary>
        /// Lista os aprovadores do centro de custo
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        public IList<AprovadorPorCC> ListByCC(CentroDeCusto custo)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x=> x.CC == custo)
                              .List();

            return list;
        }

        /// <summary>
        /// Retorna um único registro pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AprovadorPorCC GetById(int id)
        {
            var list = session.QueryOver<AprovadorPorCC>()
                              .Where(x => x.Id == id)
                              .SingleOrDefault();

            return list;
        }


        /// <summary>
        /// Faz a inclusão de um registro 
        /// </summary>
        /// <param name="amarracao"></param>
        public void Incluir(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(amarracao);
            tran.Commit();
        }

        /// <summary>
        /// Faz a alteração de um registo
        /// </summary>
        /// <param name="amarracao"></param>
        public void Alterar(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(amarracao);
            tran.Commit();
        }

        /// <summary>
        /// Faz a exlcusão de um registro 
        /// </summary>
        /// <param name="amarracao"></param>
        public void Excluir(AprovadorPorCC amarracao)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(amarracao);
            tran.Commit();
        }

    }
}
