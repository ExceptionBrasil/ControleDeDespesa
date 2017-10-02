using MenuControl.DAO;
using MenuControl.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuControl.Controllers
{
    public class MenuBuilderController : Controller
    {
        private MenuItemDAO menuDAO;

        public MenuBuilderController(MenuItemDAO m)
        {
            this.menuDAO = m;
        }

        // GET: MenuBuilder
        public ActionResult Index()
        {
            var model = menuDAO.ListAll();
            return View(model);
        }

        // GET: MenuBuilder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuBuilder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuBuilder/Create
        [HttpPost]
        public ActionResult Create(MenuItem item)
        {
            try
            {
                menuDAO.Incluir(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuBuilder/Edit/5
        public ActionResult Edit(int id)
        {
            var model = menuDAO.GetById(id);

            return View(model);
        }

        // POST: MenuBuilder/Edit/5
        [HttpPost]
        public ActionResult Edit(MenuItem item)
        {
            
            try
            {
                menuDAO.Alterar(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuBuilder/Delete/5
        public ActionResult Delete(int id)
        {
            var model = menuDAO.GetById(id);
            return View(model);
        }

        // POST: MenuBuilder/Delete/5
        [HttpPost]
        public ActionResult Delete(  MenuItem item)
        {
            try
            {

                menuDAO.Excluir(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public JsonResult GetMenu(string code)
        {
            List<MenuItem> menu = new List<MenuItem>();
            menu = menuDAO.GetByCode(code).ToList();
            string outputJson = JsonConvert.SerializeObject(menu);

            return Json( new {success = true, json = outputJson  });

        }
    }
}
