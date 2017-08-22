using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ControleDeDespesas.Models
{
    public class Despesas
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual TiposDeDespesas Tipo { get; set; }

        [Required]
        [MinLength(1)]        
        public virtual double Quantidade { get; set; }

        [Required]
        [MinLength(1)]
        public virtual double Valor { get; set; }

        public virtual string Descritivo { get; set; }
        public virtual string Attachment { get; set; }
    }
}