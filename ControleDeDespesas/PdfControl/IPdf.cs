using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfControl;

namespace InterfacesPdf
{
   public interface IPdf
    {

        PdfModel Pdf { get; set; }

        bool Create(float[] margens,bool SetCreationDate,bool setAutor, Rectangle pagina); //Prepara o PDF        
       
        PdfWriter SetWriter(); //seta o writer
        void Build(object obj); //constroi o PDF
        PdfModel Get(); //Retorna o path completo 
        bool CloseDocument(); //Fecha o documento
        bool OpenDocument(); //Abre o documento

    }
}
