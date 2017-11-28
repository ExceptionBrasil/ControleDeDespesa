using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMenu
{
    /// <summary>
    /// Classe auxiliar para montar uma lista com todas as Roles
    /// </summary>
    public class BuildRoles
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public BuildRoles(int role, string descri)
        {
            this.Id = role;
            this.Descricao = descri;
        }
    }
}
