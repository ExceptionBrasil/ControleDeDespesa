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

        public void ChangePassword(int userId, string novaSenha)
        {
            var usuario = GetById(userId);
            usuario.Senha = novaSenha;

            Altera(usuario);
            
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
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public CadastroDeUsuario GetByEmail(string email)
        {
            CadastroDeUsuario usuario = session.QueryOver<CadastroDeUsuario>()
                                               .Where(u => u.Email == email)
                                               .SingleOrDefault();
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