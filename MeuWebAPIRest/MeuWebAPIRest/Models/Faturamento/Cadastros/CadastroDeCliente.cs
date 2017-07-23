using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuWebAPIRest.Models.Faturamento.Cadastros
{
    public class CadastroDeCliente
    {
        public virtual int Id{get;set;}
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Endereco { get; set; }
    }
}