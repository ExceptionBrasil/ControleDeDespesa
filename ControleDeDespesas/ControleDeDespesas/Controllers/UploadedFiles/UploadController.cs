using Modelos;
using Persistence.DAO.Upload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];

                    if (file.ContentLength > 0)
                    {
                        CadastroDeUsuario usuario = (CadastroDeUsuario)Session["Usuario"];
                        UploadedFile uFile = new UploadedFile()
                        {
                            DataUpload = (DateTime)Session["dataEstatica"],
                            FileName = Path.GetFileName(file.FileName),
                            Path = Server.MapPath("~/Content/Images/Users/" + Convert.ToString(usuario.Id)),
                            usuario = usuario,
                            RandomName = Path.GetRandomFileName()
                        };
                    
                        //Verificar se esse nome já não existe na base de dados 
                        //se ja exitir gerar um novo nome 

                        string fileName = uFile.RandomName;

                        string path = Path.Combine(uFile.Path,fileName);

                        file.SaveAs(path);                       
                        
                        uFile.Size = new FileInfo(uFile.Path).Length;
                        uFile.Tipo = new FileInfo(uFile.Path).Extension;
                        


                    }

                }   
               
            }
            catch
            {

            }
            return View();
        }
    }
}