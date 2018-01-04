using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfControl
{
    class PdfCreate
    {
        public Document Documento { get; private set; }

        public PdfCreate(string titulo)
        {
            //Cria um preset do PDF
            this.Documento = new Document(PageSize.A4);
            Documento.SetMargins(30, 30, 30, 30);
            Documento.AddCreationDate();
            Documento.AddTitle(titulo);          
            
            //Grava o Pdf em disco
            //string path = @"C:\temp\";
            //PdfWriter pdf = PdfWriter.GetInstance(documento, new System.IO.FileStream(path, FileMode.Create));

        }

        public void AddTable(int colunas)
        {
            PdfPTable tabela = new PdfPTable(colunas);
        }

        
    }
}
