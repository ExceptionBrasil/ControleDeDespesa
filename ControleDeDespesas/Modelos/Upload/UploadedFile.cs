using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class UploadedFile
    {
        public virtual int Id { get; set; }
        public virtual CadastroDeUsuario usuario { get; set; }
        public virtual DateTime DataUpload { get; set; }      
          
        public virtual string FileName { get; set; }
        public virtual string RandomName { get; set; }
        public virtual long Size { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Path { get; set; }
    }
}
