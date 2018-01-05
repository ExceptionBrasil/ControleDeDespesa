using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistencia.DAO
{
    public class UsuariosDAO
    {
        private ISession session;

        public UsuariosDAO (ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Adiciona uma novo usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void Adiciona (CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void Exclui(CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(usuario);
            transacao.Commit();
        }

        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void Altera(CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Merge(usuario);
            transacao.Commit();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CadastroDeUsuario GetById(int id)
        {
            CadastroDeUsuario usuario = session.QueryOver<CadastroDeUsuario>()
                                  .Where(u => u.Id == id)
                                  .SingleOrDefault<CadastroDeUsuario>();
            return usuario;
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        public IList<CadastroDeUsuario> ListAll()
        {
            var list = session.QueryOver<CadastroDeUsuario>()
                              .List();
            return list;
        }

    }
}