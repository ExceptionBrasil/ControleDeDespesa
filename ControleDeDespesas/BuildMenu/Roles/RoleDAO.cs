using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    public class RoleDAO
    {
        public List<RoleView> ListRole = new List<RoleView>();

        public RoleDAO()
        {
            this.ListRole.Add(new RoleView() { Descricao = "Admin",Role= Role.Admin });
            this.ListRole.Add(new RoleView() { Descricao = "Aprovador", Role = Role.Approver });
            this.ListRole.Add(new RoleView() { Descricao = "Super Usuário", Role = Role.SuperUser });
            this.ListRole.Add(new RoleView() { Descricao = "Usuário", Role = Role.User });
        }

        
    }
}
