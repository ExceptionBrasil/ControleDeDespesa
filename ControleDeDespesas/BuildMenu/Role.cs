using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public static class Role
    {
        public static int User = 9000;
        public static int SuperUser = 5000;
        public static int Approver = 4000;
        public static int Admin = 1;


        /// <summary>
        /// Monta uma lista com todas as Roles
        /// </summary>
        /// <returns></returns>
        public static IList<BuildRoles> All()
        {
            IList<BuildRoles> l = new List<BuildRoles>();

            l.Add(new BuildRoles(Role.Admin, "Admin"));
            l.Add(new BuildRoles(Role.SuperUser, "Super Usuário"));
            l.Add(new BuildRoles(Role.Approver, "Aprovador"));
            l.Add(new BuildRoles(Role.User, "Usuário"));

            return l;
        }

    }
}
