using Modelos;
using Persistence.DAO.Upload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControleDeDespesas.Controllers.UploadedFiles
{
    public class UploadController : Controller
    {
        private UploadDAO uploadDAO; 

        public UploadController(UploadDAO u)
        {
            this.uploadDAO = u;
        }

        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult ErrorUpload() =>(View());

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            DateTime dataEstatica = DateTime.Now;
            Session["dataEstatica"] = dataEstatica;

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];

                    if (file.ContentLength > 0)
                    {
                        CadastroDeUsuario usuario = (CadastroDeUsuario)Session["Usuario"];

                        //Cria um novo arquivo 
                        UploadedFile uFile = new UploadedFile();

                        uFile.DataUpload = (DateTime)Session["dataEstatica"];
                        uFile.FileName = Path.GetFileName(file.FileName);
                        uFile.Path = Server.MapPath("~/Content/Images/Users/" + Convert.ToString(usuario.Id));
                        uFile.usuario = usuario;
                        uFile.RandomName = Path.ChangeExtension(Path.GetRandomFileName(),Path.GetExtension(uFile.FileName));



                    
                        //Verificar se esse nome já não existe na base de dados 
                        //se ja exitir gerar um novo nome 
                        while (!uploadDAO.ExistsRandomName(uFile.RandomName))
                        {
                            uFile.RandomName = Path.GetRandomFileName();
                        }

                        //Defie pelo nome aleatório o nome do arquivo a ser gravado no disco físico
                        string fileName = uFile.RandomName;

                        //Gera o path de destino
                        string path = Path.Combine(uFile.Path,fileName);

                        //Grava  arquivo físico
                        file.SaveAs(path);                       
                        

                        //Atualiza os dados do arquivo 
                        uFile.Size = new FileInfo(path).Length;
                        uFile.Tipo = new FileInfo(path).Extension;

                        //Persiste os dados do arquivo na base de dados 
                        uploadDAO.Incluir(uFile);
                        


                    }

                }   
               
            }
            catch(Exception ex)
            {
                return View();
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.OK); 
        }
    }
}