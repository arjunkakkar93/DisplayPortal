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
    public class PortalUpdatesController : Controller
    {
        private LTUpdatesEntities db = new LTUpdatesEntities();

        // GET: PortalUpdates
        public ActionResult Index()
        {
            return View(db.PortalUpdates.ToList());
        }

        // GET: PortalUpdates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalUpdate portalUpdate = db.PortalUpdates.Find(id);
            if (portalUpdate == null)
            {
                return HttpNotFound();
            }
            return View(portalUpdate);
        }

        // GET: PortalUpdates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortalUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ContentImage,CreatedBy")] PortalUpdate portalUpdate)
        {
            if (ModelState.IsValid)
            {
                db.PortalUpdates.Add(portalUpdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portalUpdate);
        }

        // GET: PortalUpdates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalUpdate portalUpdate = db.PortalUpdates.Find(id);
            if (portalUpdate == null)
            {
                return HttpNotFound();
            }
            return View(portalUpdate);
        }

        // POST: PortalUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ContentImage,CreatedBy")] PortalUpdate portalUpdate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portalUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portalUpdate);
        }

        // GET: PortalUpdates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalUpdate portalUpdate = db.PortalUpdates.Find(id);
            if (portalUpdate == null)
            {
                return HttpNotFound();
            }
            return View(portalUpdate);
        }

        // POST: PortalUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortalUpdate portalUpdate = db.PortalUpdates.Find(id);
            db.PortalUpdates.Remove(portalUpdate);
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
