﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Modelos
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


        public virtual CadastroDeUsuario UsuarioInclusao { get; set; }
        public virtual CadastroDeUsuario UsuarioAprovacao { get; set; }
        public virtual CadastroDeUsuario UsuarioReprovação { get; set; }

        public virtual DateTime? DataInclusao { get; set; }
        public virtual DateTime? DataAprovacao { get; set; }
        public virtual DateTime? DataReprovacao { get; set; }
        public virtual DateTime? DataIntegradoERP { get; set; }
        

        public virtual CentroDeCusto CentroDeCusto { get; set; }   
        public virtual string MotivoRecusa { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if(obj is Despesas)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += this.CentroDeCusto.GetHashCode();
            hash += this.CodigoDespesa.GetHashCode();
            hash += this.DataAprovacao.GetHashCode();
            hash += this.DataInclusao.GetHashCode();
            hash += this.DataIntegradoERP.GetHashCode();
            hash += this.DataReprovacao.GetHashCode();
            hash += this.Descritivo.GetHashCode();
            hash += this.Id.GetHashCode();
            hash += this.MotivoRecusa.GetHashCode();
            hash += this.Quantidade.GetHashCode();
            hash += this.Tipo.GetHashCode();
            hash += this.UsuarioAprovacao.GetHashCode();
            hash += this.UsuarioInclusao.GetHashCode();
            hash += this.UsuarioReprovação.GetHashCode();
            hash += this.Valor.GetHashCode();


            return hash * 7;
        }
    }    
}