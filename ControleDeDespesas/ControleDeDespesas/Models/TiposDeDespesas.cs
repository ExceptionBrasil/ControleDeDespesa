using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Models
{
    public class TiposDeDespesas
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Descricao { get; set; }

      //  public virtual bool ValorEditavel { get; set; }
    }
}