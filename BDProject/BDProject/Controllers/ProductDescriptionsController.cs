using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDProject.Models;

namespace BDProject.Controllers
{
    public class ProductDescriptionsController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: ProductDescriptions
        public ActionResult Index()
        {
            return View(db.ProductDescriptions.ToList());
        }

        // GET: ProductDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // GET: ProductDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDescriptions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,language_id,translated_name,translated_description")] ProductDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                db.ProductDescriptions.Add(productDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productDescription);
        }

        // GET: ProductDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // POST: ProductDescriptions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,language_id,translated_name,translated_description")] ProductDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productDescription);
        }

        // GET: ProductDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // POST: ProductDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            db.ProductDescriptions.Remove(productDescription);
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
