using FluentNHibernate.Mapping;
using MeuWebApi2.Model.Faturamento.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuWebApi2.Mapping.Faturamento.Cadastros
{
    public class CadastroDeClienteMapping:ClassMap<CadastroDeCliente>
    {
        public CadastroDeClienteMapping()
        {
            Table("SA1010");
            Id(A1 => A1.Id).Column("R_E_C_N_O_");
            Map(A1 => A1.Codigo).Column("A1_COD");
            Map(A1 => A1.Endereco).Column("A1_END");
            Map(A1 => A1.Cpf).Column("A1_CGC");
            Map(A1 => A1.Nome).Column("A1_NOME");
        }
    }
}