using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public class Menu
    {
        public string Descricao;
        public string Action;
        public string Controller;
        public string Role;
        public string Glyphicon;
        
        public override string ToString()
        {
            return '/'+this.Controller + '/' + Action;
        }

    }

    
}
