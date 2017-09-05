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

        public virtual int CodigoDespesa { get; set; }

        [Required]
        public virtual TiposDeDespesas Tipo { get; set; }

        [Required]
        [MinLength(1)]        
        [RegularExpression(@"\d{5}[,]\d\d")]
        public virtual double Quantidade { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression(@"\d{10}[,]\d\d")]
        public virtual double Valor { get; set; }

        public virtual string Descritivo { get; set; }
        public virtual string Attachment { get; set; }


        public virtual CadastroDeUsuario UsuarioInclusao { get; set; }
        public virtual CadastroDeUsuario UsuarioAprovacao { get; set; }

        public virtual DateTime? DataInclusao { get; set; }
        public virtual DateTime? DataAprovacao { get; set; }

        public virtual string CentroDeCusto { get; set; }
}
}