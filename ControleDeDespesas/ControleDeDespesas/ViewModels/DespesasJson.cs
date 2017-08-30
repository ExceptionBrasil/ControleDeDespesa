using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.ViewModels
{
    public class DespesasJson
    {
        public string TipoDespesaDescri { get; set; }
        public string IdTipoDespesa { get; set; }        
        public double Quantidade { get; set; }        
        public string DescricaoDespesa { get; set; }
        public double Valor { get; set; }
    }
}