using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Persistence.Mappings
{
    class CentroDeCustoMapping:ClassMap<CentroDeCusto>
    {
     public CentroDeCustoMapping()
        {
            Id(c => c.Id);
            Map(c => c.Codigo);
            Map(c => c.Descricao);
        }

    }
}
