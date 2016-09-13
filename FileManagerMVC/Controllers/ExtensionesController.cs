using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileManagerMVC.Models;

namespace FileManagerMVC.Controllers
{
    public class ExtensionesController : Controller
    {
        private FilesMVCEntities db = new FilesMVCEntities();

        // GET: Extensiones
        public ActionResult Index()
        {
            return View(db.Extension.ToList());
        }

        // GET: Extensiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extension extension = db.Extension.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        // GET: Extensiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extensiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre")] Extension extension)
        {
            if (ModelState.IsValid)
            {
                db.Extension.Add(extension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extension);
        }

        // GET: Extensiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extension extension = db.Extension.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        // POST: Extensiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre")] Extension extension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extension);
        }

        // GET: Extensiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extension extension = db.Extension.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        // POST: Extensiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extension extension = db.Extension.Find(id);
            db.Extension.Remove(extension);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
