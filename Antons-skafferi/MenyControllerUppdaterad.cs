using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntonsSkafferi.Models;
using AntonsSkafferi.Data;

namespace AntonsSkafferi.Controllers
{
    public class MenyController : Controller
    {
        private AntonsContext db = new AntonsContext();

        //
        // GET: /Meny/
        
        public ViewResult Index()
        {
            return View(db.Meny.ToList());
        }

        //
        // GET: /Meny/Details/5

        public ViewResult Details(int id)
        {
            Meny meny = db.Meny.Find(id);
            return View(meny);
        }

        //
        // GET: /Meny/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Meny/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Meny meny)
        {
            if (ModelState.IsValid)
            {
                db.Meny.Add(meny);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(meny);
        }
        
        //
        // GET: /Meny/Edit/5

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Meny meny = db.Meny.Find(id);
            return View(meny);
        }

        //
        // POST: /Meny/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Meny meny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meny);
        }

        //
        // GET: /Meny/Delete/5

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Meny meny = db.Meny.Find(id);
            return View(meny);
        }

        //
        // POST: /Meny/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Meny meny = db.Meny.Find(id);
            db.Meny.Remove(meny);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Meny/Planned

        [Authorize(Roles = "Admin")]
        public ViewResult Planned()
        {
            return View(db.Meny.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}