using NHibernate;
using Persistencia.DAO;
using Factorys.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Ninject
{
    public class  Injections
    {
        private static ISession session = NhibernateHelper.OpenSession();
          
        //
        //Carregue seus módulos de insjenção aqui!
        //

        public static CentroDeCustoDAO CentroDeCustoInject() => new CentroDeCustoDAO(session);        
        public static UsuariosDAO UsuarioInject() => new UsuariosDAO(session);
        public static TiposDeDespesasDAO GetTiposDeDespesasInject() =>new TiposDeDespesasDAO(session);

    }
}
