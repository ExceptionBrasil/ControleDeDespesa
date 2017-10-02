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


        /// <summary>
        /// Lista todos os menus
        /// </summary>
        /// <returns></returns>
        public IList<MenuItem> ListAll()
        {
            var menu = session.QueryOver<MenuItem>()                        
                              .List();
            return menu;
        }

        /// <summary>
        /// Obtem um menu pelo código
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IList<MenuItem> GetByCode(string code)
        {
            var menu = session.QueryOver<MenuItem>()
                              .Where(x => x.Code == code)
                              .List();
            return menu;
        }

        /// <summary>
        /// Obtem um item do menu pelo Id dele.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MenuItem GetById(int id)
        {
            var menu = session.QueryOver<MenuItem>()
                              .Where(x => x.Id == id)
                              .List()
                              .SingleOrDefault();
            return menu;
        }

        /// <summary>
        /// Inclui um item de menu
        /// </summary>
        /// <param name="menu">The menu.</param>
        public void Incluir (MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(menu);
            tran.Commit();
        }

        /// <summary>
        /// Exclui um item de Menu
        /// </summary>
        /// <param name="menu">The menu.</param>
        public void Excluir(MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(menu);
            tran.Commit();
        }

        /// <summary>
        /// Altera um item de menu
        /// </summary>
        /// <param name="menu">The menu.</param>
        public void Alterar(MenuItem menu)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(menu);
            tran.Commit();
        }

    }
}