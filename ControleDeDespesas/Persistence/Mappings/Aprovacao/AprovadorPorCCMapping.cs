using FluentNHibernate.Mapping;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    public class AprovadorPorCCMapping:ClassMap<AprovadorPorCC>
    {
        public AprovadorPorCCMapping()
        {
            Id(a => a.Id);
            References(a => a.Usuario);
            References(a => a.CC);
        }
    }
}
