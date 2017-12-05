using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Helpers
{
    public static class ConfigureHelper
    {
        static Configuration Cfg = new Configuration();
        
        public static string Key(string key)
        {
            ConfigureHelper.Cfg.Configure();
            return Cfg.Properties[key].ToString();

        }
    }
}
