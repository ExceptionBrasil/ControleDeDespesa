using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.ViewModels
{
    public class DespesasJson
    {

        
        public int IdDespesa { get; set; }
        public string DespesaDescricao { get; set; }        
        public double Quantidade { get; set; }        
        public double Valor { get; set; }
        public string Observacao { get; set; }

    }

}