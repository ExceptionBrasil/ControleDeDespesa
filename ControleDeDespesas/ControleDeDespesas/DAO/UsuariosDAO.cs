using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.DAO
{
    public class UsuariosDAO
    {
        private ISession session;

        public UsuariosDAO (ISession session)
        {
            this.session = session;
        }



    }
}