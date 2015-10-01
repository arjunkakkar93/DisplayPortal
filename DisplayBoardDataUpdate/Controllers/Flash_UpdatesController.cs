using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayBoardDataUpdate.Models;
using DisplayBoardDataUpdate.CustomAttributtes;

namespace DisplayBoardDataUpdate.Controllers
{
    [AuthAuthorization(Authorized = true)]
    public class Flash_UpdatesController : Controller
    {
        private LTUpdatesEntities db = new LTUpdatesEntities();

        // GET: Flash_Updates
        public ActionResult Index()
        {
            return View(db.Flash_Updates.ToList());
        }

        // GET: Flash_Updates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash_Updates flash_Updates = db.Flash_Updates.Find(id);
            if (flash_Updates == null)
            {
                return HttpNotFound();
            }
            return View(flash_Updates);
        }

        // GET: Flash_Updates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flash_Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,CreatedBy,Title")] Flash_Updates flash_Updates)
        {
            if (ModelState.IsValid)
            {
                db.Flash_Updates.Add(flash_Updates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flash_Updates);
        }

        // GET: Flash_Updates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash_Updates flash_Updates = db.Flash_Updates.Find(id);
            if (flash_Updates == null)
            {
                return HttpNotFound();
            }
            return View(flash_Updates);
        }

        // POST: Flash_Updates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,CreatedBy,Title")] Flash_Updates flash_Updates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flash_Updates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flash_Updates);
        }

        // GET: Flash_Updates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash_Updates flash_Updates = db.Flash_Updates.Find(id);
            if (flash_Updates == null)
            {
                return HttpNotFound();
            }
            return View(flash_Updates);
        }

        // POST: Flash_Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flash_Updates flash_Updates = db.Flash_Updates.Find(id);
            db.Flash_Updates.Remove(flash_Updates);
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
