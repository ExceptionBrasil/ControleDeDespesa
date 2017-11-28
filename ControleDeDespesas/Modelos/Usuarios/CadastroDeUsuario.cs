using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class CadastroDeUsuario
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Nome { get; set; }

        [Required]
        public virtual string Login { get; set; }

        [Required]
        public virtual string Senha { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]        
        public virtual string Email { get; set; }

        public virtual bool IsAdmin { get; set; }
        

        [Required]
        public virtual string Cpf { get; set; }

        [Required]
        public virtual CentroDeCusto CentroDeCusto { get; set; }        

        [Required]
        public virtual int Role { get; set; }
    }
}