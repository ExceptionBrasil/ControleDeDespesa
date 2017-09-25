using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using System.Reflection;

namespace Persistencia.Helpers
{
    public class NhibernateHelper
    {
        private static ISessionFactory fatory = BuildSession();

        private static ISessionFactory BuildSession()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            return Fluently.Configure(cfg)
              .Mappings(x =>
                     x.FluentMappings.AddFromAssembly(
                Assembly.GetExecutingAssembly()
                )
              ).BuildSessionFactory();

        }

        public static ISession OpenSession()
        {
            return fatory.OpenSession();
        }
    }
}