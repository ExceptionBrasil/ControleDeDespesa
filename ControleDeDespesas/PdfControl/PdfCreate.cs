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
    public class PdfCreate
    {
        public Document Documento { get; private set; }

        public PdfCreate(string titulo, string path)
        {
            //Cria um preset do PDF
            this.Documento = new Document(PageSize.A4);
            Documento.SetMargins(30, 30, 30, 30);
            Documento.AddCreationDate();
            Documento.AddTitle(titulo);



            //Destino do arquivo 
           
            //Cria  writer
             PdfWriter writer = PdfWriter.GetInstance(Documento, new FileStream(path, FileMode.Create));

            //Abre o documento
            Documento.Open();

            //Cria o parágrafo
            Paragraph paragrafo = new Paragraph("Hello Word", new Font(Font.NORMAL, 14));

            //Alinhamento
            paragrafo.Alignment = Element.ALIGN_LEFT;

            //Adiciona um textinho
            paragrafo.Add("123 zzz");

            //adiciona o paragrafo no documento


            Documento.Add(paragrafo);

            Documento.Close();



        }

        public void AddTable(int colunas)
        {
            PdfPTable tabela = new PdfPTable(colunas);
        }


            
    }
}
