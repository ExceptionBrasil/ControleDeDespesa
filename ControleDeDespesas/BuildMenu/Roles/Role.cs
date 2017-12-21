using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public static class Role
    {

        /*
         * A Regra de visualização por role segue o critério de maior e igual á:
         * Exemplo,
         * 
         * Traga todos os menus que são da Localização XX e que tem uma regra maior que ou igual a Admin
         * Resultado, virá os menus:
         * 
         * Admin, Approver, SuperUser, User e Viewer
         * 
         */

        public static int Viewer = 10000;
        public static int User = 9000;
        public static int SuperUser = 5000;
        public static int Approver = 4000;
        public static int Admin = 1;

        
    }
}
