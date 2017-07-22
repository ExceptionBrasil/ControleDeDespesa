using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ControleDeDespesas.Models
{
    public class Despesas
    {
        public virtual int Id { get; set; }
        public virtual TiposDeDespesas Tipo { get; set; }
        public virtual double Valor { get; set; }
        public virtual string Descritivo { get; set; }
        public virtual string Attachment { get; set; }
    }
}