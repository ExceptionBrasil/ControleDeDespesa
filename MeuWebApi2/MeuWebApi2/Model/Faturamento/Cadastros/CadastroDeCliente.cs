using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuWebApi2.Model.Faturamento.Cadastros
{
    public class CadastroDeCliente
    {
        public virtual int Id { get; set; } //Recno
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Cpf { get; set; }
    }
}