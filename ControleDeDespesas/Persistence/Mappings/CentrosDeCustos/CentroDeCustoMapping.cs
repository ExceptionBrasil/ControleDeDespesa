using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Persistencia.Mappings
{
    public class CentroDeCustoMapping:ClassMap<CentroDeCusto>
    {
     public CentroDeCustoMapping()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Codigo).Unique();
            Map(c => c.Descricao);
            References(c => c.Aprovador);
            
        }

    }
}
