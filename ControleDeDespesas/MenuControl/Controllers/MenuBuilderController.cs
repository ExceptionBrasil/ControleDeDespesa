using MenuControl.DAO;
using MenuControl.Models;
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
            return View();
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
            return View();
        }

        // POST: MenuBuilder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                menuDAO.Alterar(menuDAO.GetById(id));

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
            return View();
        }

        // POST: MenuBuilder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
