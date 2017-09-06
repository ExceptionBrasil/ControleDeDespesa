using ControleDeDespesas.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Mappings
{
    public class TiposDeDespesasMapping:ClassMap<TiposDeDespesas>
    {
        public TiposDeDespesasMapping()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Descricao);
            Map(t => t.ValorFixo);
        }
    
    }
}