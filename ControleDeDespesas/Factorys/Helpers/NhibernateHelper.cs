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
using FluentNHibernate.Automapping;

namespace Factorys.Helpers
{
    public class NhibernateHelper
    {
        private static ISessionFactory fatory = BuildSession();

        private static ISessionFactory BuildSession()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            
            return Fluently.Configure(cfg)
              //.Database(MySQLConfiguration.Standard.ConnectionString())
              //Carrega os mapeamentos do Modelo Persistencias
              // x.AutoMappings.Add(AutoMap.Assembly(Assembly.Load("Persistencia"))) //AutoMapping
              .Mappings(x => 
                     x.FluentMappings.AddFromAssembly(
                  Assembly.Load("Persistencia")//LoadWithPartialName("Persistencia")//GetExecutingAssembly()     //Pegar o assemply atual em execução           
                )
                
              ).BuildSessionFactory();
            
        }

        public static ISession OpenSession()
        {
            return fatory.OpenSession();
        }
    }
}