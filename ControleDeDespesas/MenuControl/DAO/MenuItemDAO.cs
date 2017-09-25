using MenuControl.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuControl.DAO
{
    public class MenuItemDAO
    {
        private ISession session;

        public MenuItemDAO(ISession sessao)
        {
            this.session = sessao;
        }

        public IList<MenuItem> ListAll()
        {
            var menu = session.QueryOver<MenuItem>()                        
                              .List();
            return menu;
        }

        public IList<MenuItem> GetByCode(string code)
        {
            var menu = session.QueryOver<MenuItem>()
                              .Where(x => x.Code == code)
                              .List();
            return menu;
        }

        public MenuItem GetById(int id)
        {
            var menu = session.QueryOver<MenuItem>()
                              .Where(x => x.Id == id)
                              .List()
                              .SingleOrDefault();
            return menu;
        }

        public void Incluir (MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(menu);
            tran.Commit();
        }

        public void Excluir(MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(menu);
            tran.Commit();
        }

        public void Alterar(MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(menu);
            tran.Commit();
        }

    }
}