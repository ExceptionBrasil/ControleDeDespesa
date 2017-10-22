using FluentNHibernate.Mapping;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Mappings
{
    public class AprovadorPorCCMapping:ClassMap<AprovadorPorCC>
    {
        public AprovadorPorCCMapping()
        {
            Id(a => a.Id).GeneratedBy.Identity();
            References(a => a.Usuario);
            References(a => a.CC);
            References(a => a.Superior);
            Map(a => a.Limite);

        }
    }
}
