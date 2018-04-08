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
    public class ProductInformationsController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: ProductInformations
        public ActionResult Index()
        {
            return View(db.ProductInformations.ToList());
        }

        // GET: ProductInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInformation productInformation = db.ProductInformations.Find(id);
            if (productInformation == null)
            {
                return HttpNotFound();
            }
            return View(productInformation);
        }

        // GET: ProductInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductInformations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,product_description,category_id,weight_class,warranty_period,supplier_id,product_status,list_price,min_price,catalog_url")] ProductInformation productInformation)
        {
            if (ModelState.IsValid)
            {
                db.ProductInformations.Add(productInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productInformation);
        }

        // GET: ProductInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInformation productInformation = db.ProductInformations.Find(id);
            if (productInformation == null)
            {
                return HttpNotFound();
            }
            return View(productInformation);
        }

        // POST: ProductInformations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_description,category_id,weight_class,warranty_period,supplier_id,product_status,list_price,min_price,catalog_url")] ProductInformation productInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productInformation);
        }

        // GET: ProductInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInformation productInformation = db.ProductInformations.Find(id);
            if (productInformation == null)
            {
                return HttpNotFound();
            }
            return View(productInformation);
        }

        // POST: ProductInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductInformation productInformation = db.ProductInformations.Find(id);
            db.ProductInformations.Remove(productInformation);
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
