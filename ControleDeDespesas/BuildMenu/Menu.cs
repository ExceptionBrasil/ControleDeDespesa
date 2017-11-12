using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public class Menu
    {
        public string Controller;
        public string Action;
        public string Location;
        public string Descricao;
        public string Role;        
        
        public override string ToString()
        {
            return '/'+this.Controller + '/' + Action;
        }

    }

    
}
