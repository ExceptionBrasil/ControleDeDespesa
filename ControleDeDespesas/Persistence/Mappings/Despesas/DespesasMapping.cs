using Modelos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistencia.Mappings
{
    public class DespesasMapping:ClassMap<Despesas>
    {
        public DespesasMapping()
        {
            Id(d => d.Id).GeneratedBy.Identity();
            Map(d => d.CodigoDespesa);
            References(d => d.Tipo);
            Map(d => d.Valor);
            Map(d => d.Quantidade);
            Map(d => d.Descritivo);
            Map(d => d.Attachment);
            Map(d => d.DataInclusao);
            Map(d => d.DataAprovacao);
            References(d => d.UsuarioInclusao);
            References(d => d.UsuarioAprovacao);
            References(d => d.CentroDeCusto);

        }
    }
}