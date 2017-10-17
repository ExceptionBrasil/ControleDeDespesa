using Modelos;
using Modelos.ViewModels;
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

        public void Adiciona (CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        }
        public void Exclui(CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(usuario);
            transacao.Commit();
        }
        public void Altera(CadastroDeUsuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Merge(usuario);
            transacao.Commit();
        }

        public CadastroDeUsuario GetById(int id)
        {
            var usuario = session.QueryOver<CadastroDeUsuario>()
                                  .Where(u => u.Id == id)
                                  .SingleOrDefault<CadastroDeUsuario>();
            return usuario;
        }

        public  IList<CadastroDeUsuario> ListAll()
        {
            var list = session.QueryOver<CadastroDeUsuario>()
                              .List();
            return list;
        }

    }
}