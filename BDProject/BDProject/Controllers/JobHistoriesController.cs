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
    public class JobHistoriesController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: JobHistories
        public ActionResult Index()
        {
            var jobHistories = db.JobHistories.Include(j => j.Department).Include(j => j.Employee).Include(j => j.Job);
            return View(jobHistories.ToList());
        }

        // GET: JobHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public ActionResult Create()
        {
            ViewBag.department_id = new SelectList(db.Departments, "department_id", "department_name");
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "first_name");
            ViewBag.job_id = new SelectList(db.Jobs, "job_id", "job_title");
            return View();
        }

        // POST: JobHistories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_id,start_date,end_date,job_id,department_id")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                db.JobHistories.Add(jobHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department_id = new SelectList(db.Departments, "department_id", "department_name", jobHistory.department_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "first_name", jobHistory.employee_id);
            ViewBag.job_id = new SelectList(db.Jobs, "job_id", "job_title", jobHistory.job_id);
            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.department_id = new SelectList(db.Departments, "department_id", "department_name", jobHistory.department_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "first_name", jobHistory.employee_id);
            ViewBag.job_id = new SelectList(db.Jobs, "job_id", "job_title", jobHistory.job_id);
            return View(jobHistory);
        }

        // POST: JobHistories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,start_date,end_date,job_id,department_id")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department_id = new SelectList(db.Departments, "department_id", "department_name", jobHistory.department_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "first_name", jobHistory.employee_id);
            ViewBag.job_id = new SelectList(db.Jobs, "job_id", "job_title", jobHistory.job_id);
            return View(jobHistory);
        }

        // GET: JobHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobHistory jobHistory = db.JobHistories.Find(id);
            db.JobHistories.Remove(jobHistory);
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
