using ControleDeDespesas.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Mappings
{
    public class DespesasMapping:ClassMap<Despesas>
    {
        public DespesasMapping()
        {
            Id(d => d.Id).GeneratedBy.Identity();
            References(d => d.Tipo);
            Map(d => d.Valor);
            Map(d => d.Quantidade);
            Map(d => d.Descritivo);
            Map(d => d.Attachment);

        }
    }
}