using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using iTextSharp.text;

namespace PdfControl
{
    public class PdfModel
    {
        public string Titulo { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public Document Document { get; set; }
        public float[] Margens = new float[4] { 05, 05, 05, 05 };
        public DateTime CreationDate { get;set; }
        public string Autor { get; set; }
        public Rectangle pagina { get; set; }

    }
}
