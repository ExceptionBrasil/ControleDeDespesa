using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using System.Reflection;
using FluentNHibernate.Cfg.Db;

namespace MeuWebAPIRest.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory fatory = BuildSession();

        private static ISessionFactory BuildSession()
        {
            /*Configuration cfg = new Configuration();
            cfg.Configure();

            return Fluently.Configure(cfg)
              .Mappings(x =>
                     x.FluentMappings.AddFromAssembly(
                Assembly.GetExecutingAssembly()
                )
              ).BuildSessionFactory();*/
            
            var ret = Fluently.Configure()
           .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=localhost;Database=ProtheusBasico;Integrated Security=True").ShowSql)
           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServerData>())
           .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
           .BuildSessionFactory();
        }

            return ret;

        }

        public static ISession OpenSession()
        {
            return fatory.OpenSession();
        }
    }
}