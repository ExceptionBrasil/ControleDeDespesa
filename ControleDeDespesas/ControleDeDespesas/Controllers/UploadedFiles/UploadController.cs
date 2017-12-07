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
                        string fileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/WeekUploadedFiles"), fileName);
                        file.SaveAs(path);  
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