using InterfacesPdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfControl
{
    public class ViewDespesaPdf:IPdf
    {
        public PdfModel Pdf { get;  set; }
      

        private float[] ms = new float[4] { 30, 30, 30, 30 };

        /// <summary>
        /// Inicializa a intancia do <see cref="ViewDespesaPdf"/> class.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="autor">The autor.</param>
        public ViewDespesaPdf(string titulo,string path,string fileName, string autor)
        {
            Pdf = new PdfModel();

            this.Pdf.Titulo = titulo;
            this.Pdf.Path = path;
            this.Pdf.FileName = fileName;
            this.Pdf.FullPath = path.Trim() + fileName.Trim();
            this.Pdf.Autor=autor;

            //Define as margens default 
            this.Pdf.Margens = ms;
        }



        /// <summary>
        /// Pre-sets do documento.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="margens">The margens.</param>
        /// <param name="SetCreationDate">if set to <c>true</c> [set creation date].</param>
        /// <param name="setAutor">if set to <c>true</c> [set autor].</param>
        /// <param name="pagina">The pagina.</param>
        /// <returns></returns>
        public bool Create(float[] margens=null,bool SetCreationDate=true, bool setAutor=true, Rectangle pagina=null)
        {
            
            if(pagina == null)
            {
                pagina = PageSize.A4;
            }

            this.Pdf.Document = new Document(pagina);

            if (margens != null)
            {
                Pdf.Document.SetMargins(margens[0], margens[1], margens[2], margens[3]);
            }else
            {
                Pdf.Document.SetMargins(this.Pdf.Margens[0], this.Pdf.Margens[1], this.Pdf.Margens[2], this.Pdf.Margens[3]);
            }

            Pdf.Document.AddCreationDate();
            Pdf.Document.AddAuthor(this.Pdf.Autor);
            Pdf.Document.AddTitle(this.Pdf.Titulo);
            

            return true;

        }

        /// <summary>
        /// Builds the PDF.
        /// </summary>
        public void Build(object obj)
        {
            if (obj == null)
            {
                throw new Exception("Objeto nullo");
            }

            if (!(obj is  IList<Despesas>))
            {
                throw new Exception("Objeto não é do tipo IList<Despesas>");
            }
            IList<Despesas> despesas = (IList<Despesas>)obj;

            //Cria o Writer
            PdfWriter writer = SetWriter();

            //Abre o documento
            OpenDocument();


            Paragraph tituloRDV = new Paragraph();
            tituloRDV.Font = Fonte("Calibri", 16, true);
            tituloRDV.Add("RDV: " + despesas.First().CodigoDespesa);
            tituloRDV.Alignment = Element.ALIGN_LEFT;


            PdfPTable tableHeader = new PdfPTable(5);
            PdfPCell tableHeaderCell = new PdfPCell();
            tableHeaderCell.Border = 1;
            tableHeaderCell.AddElement(tituloRDV);

            tableHeader.AddCell(tableHeaderCell);


            
            Pdf.Document.Add(tableHeader);
            
            


            //Fecha o documento
            CloseDocument();



        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public PdfModel Get()
        {
            return Pdf;
        }

        /// <summary>
        /// Cria um novo Writer
        /// </summary>
        /// <returns></returns>
        public PdfWriter SetWriter()
        {
            PdfWriter writer = PdfWriter.GetInstance(this.Pdf.Document, new FileStream(this.Pdf.FullPath, FileMode.Create));
            return writer;
        }
        /// <summary>
        /// Closes the document.
        /// </summary>
        /// <returns></returns>
        public bool CloseDocument()
        {

             this.Pdf.Document.Close();
            return true;
        }
        /// <summary>
        /// Opens the document.
        /// </summary>
        /// <returns></returns>
        public bool OpenDocument()
        {
            this.Pdf.Document.Open();
            return true;
        }

        /// <summary>
        /// Especifica a Fonte
        /// </summary>
        /// <param name="family">The family.</param>
        /// <param name="size">The size.</param>
        /// <param name="bold">if set to <c>true</c> [bold].</param>
        /// <param name="italic">if set to <c>true</c> [italic].</param>
        /// <param name="underline">if set to <c>true</c> [underline].</param>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public Font Fonte(string family="Times New Roman",int size=8,bool bold=false,bool italic=false, bool underline=false,int R=0,int G=0, int B=0)
        {
            Font F = new Font();

            F.SetFamily(family);
            F.SetColor(R, G, B);
            F.Size = size;

            //Estilo da fonte
            if(bold) F.SetStyle("bold");
            if(italic) F.SetStyle("italic");
            if(underline) F.SetStyle("underline");
            if(!bold  && !italic && !underline) F.SetStyle("normal");
            


            return F;
            
        }

        

            



            
    }
}
