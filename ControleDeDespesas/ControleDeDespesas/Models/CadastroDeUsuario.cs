using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Models
{
    public class CadastroDeUsuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string CentroDeCusto { get; set; }        
    }
}