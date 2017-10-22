using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class AprovadorPorCCModelView
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Superior { get; set; }
        public int CC { get; set; }
        public double Limite { get; set; }
    }
}
