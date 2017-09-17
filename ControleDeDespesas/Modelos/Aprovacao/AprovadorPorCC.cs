using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class AprovadorPorCC
    {
        public virtual int Id { get; set; }
        public virtual CadastroDeUsuario Usuario { get; set; }
        public virtual CentroDeCusto CC { get; set; }
    }
}
