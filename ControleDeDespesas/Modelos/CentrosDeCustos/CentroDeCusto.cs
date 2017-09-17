using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   public class CentroDeCusto
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
    }
}
