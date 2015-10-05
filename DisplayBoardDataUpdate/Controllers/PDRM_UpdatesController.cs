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
using System.IO;
using DisplayBoardDataUpdate.Models.ViewModels;
using DisplayBoardDataUpdate.Mappers;

namespace DisplayBoardDataUpdate.Controllers
{
    [AuthAuthorization(Authorized = true)]
    public class PDRM_UpdatesController : Controller
    {
        private LTUpdatesEntities db = new LTUpdatesEntities();

        // GET: PDRM_Updates
        public ActionResult Index()
        {
            return View(db.PDRM_Updates.ToList());
        }

        // GET: PDRM_Updates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDRM_Updates pDRM_Updates = db.PDRM_Updates.Find(id);
            if (pDRM_Updates == null)
            {
                return HttpNotFound();
            }
            return View(pDRM_Updates);
        }

        // GET: PDRM_Updates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDRM_Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Title,CreatedBy")] PdrmUpdatesVM pDRM_Updates)
        {
            if (ModelState.IsValid)
            {
                var fi = Path.GetFileName(pDRM_Updates.Description.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fi);
                pDRM_Updates.Description.SaveAs(path);

                AzureController blobUpload = new AzureController("pdrmupdates-images");
                string blobURL = blobUpload.AddToBlobStorage(path, pDRM_Updates.Title);
                PDRM_Updates pdrmupdate = DisplayBoardUpdatesMapper.pdrmUpdateMapper(pDRM_Updates);
                pdrmupdate.Description = blobURL;
                db.PDRM_Updates.Add(pdrmupdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDRM_Updates);
        }

        // GET: PDRM_Updates/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PDRM_Updates pDRM_Updates = db.PDRM_Updates.Find(id);
        //    if (pDRM_Updates == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pDRM_Updates);
        //}

        //// POST: PDRM_Updates/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Description,Title,CreatedBy")] PDRM_Updates pDRM_Updates)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pDRM_Updates).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(pDRM_Updates);
        //}

        // GET: PDRM_Updates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDRM_Updates pDRM_Updates = db.PDRM_Updates.Find(id);
            if (pDRM_Updates == null)
            {
                return HttpNotFound();
            }
            return View(pDRM_Updates);
        }

        // POST: PDRM_Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDRM_Updates pDRM_Updates = db.PDRM_Updates.Find(id);
            db.PDRM_Updates.Remove(pDRM_Updates);
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
