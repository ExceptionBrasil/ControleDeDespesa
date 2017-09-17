using ControleDeDespesas.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Mappings
{
    public class TiposDespesasMapping:ClassMap<TiposDespesas>
    {
        public TiposDespesasMapping()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Descricao);
        }
    }
}