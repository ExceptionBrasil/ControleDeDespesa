using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.ViewModels
{
    public class DespesasJson
    {
        public string tipoDespesa { get; set; }
        public string tipoDespesaDescricao { get; set; }        
        public double quantidade { get; set; }        
        public double valor { get; set; }
        public string descricao { get; set; }
    }
}