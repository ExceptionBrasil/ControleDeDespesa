using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Persistence.Mappings
{
    class UploadFileMapping: ClassMap<UploadedFile>
    {
        public UploadFileMapping()
        {
            Id(x => x.Id);
            Map(x => x.FileName);
            Map(x => x.Path);
            Map(x => x.Size);
            Map(x => x.Tipo);
        }
    }
}
