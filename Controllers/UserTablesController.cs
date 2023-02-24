using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantFinder.Controllers
{
    public class UserTablesController : Controller
    {
        // GET: UserTables
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserTables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTables/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTables/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserTables/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserTables/Delete/5
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
