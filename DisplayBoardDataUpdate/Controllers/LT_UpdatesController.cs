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
using DisplayBoardDataUpdate.Mappers;
using DisplayBoardDataUpdate.Models.ViewModels;

namespace DisplayBoardDataUpdate.Controllers
{
    [AuthAuthorization(Authorized = true)]
    public class LT_UpdatesController : Controller
    {
       
        private LTUpdatesEntities db = new LTUpdatesEntities();

        // GET: LT_Updates
        public ActionResult Index()
        {
            return View(db.LT_Updates.ToList());
        }

        // GET: LT_Updates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LT_Updates lT_Updates = db.LT_Updates.Find(id);
            if (lT_Updates == null)
            {
                return HttpNotFound();
            }
            return View(lT_Updates);
        }

        
        // GET: LT_Updates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LT_Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,CreatedBy,Description,Content_URL")] ltUpdatesVM lT_Updates)
        {
            if (ModelState.IsValid)
            {
                    var fi=Path.GetFileName(lT_Updates.Content_URL.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fi);
                    lT_Updates.Content_URL.SaveAs(path);

                AzureController blobUpload = new AzureController("ltupdates-images");
                string blobURL = blobUpload.AddToBlobStorage(path, lT_Updates.Title);
                LT_Updates ltupdate = DisplayBoardUpdatesMapper.ltUpdateMapper(lT_Updates);
                ltupdate.Content_URL = blobURL;
                db.LT_Updates.Add(ltupdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lT_Updates);
        }

        // GET: LT_Updates/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LT_Updates lT_Updates = db.LT_Updates.Find(id);
            
        //    if (lT_Updates == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lT_Updates);
        //}

        //// POST: LT_Updates/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Title,CreatedBy,Description,Content_URL")] LT_Updates lT_Updates)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(lT_Updates).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(lT_Updates);
        //}

        // GET: LT_Updates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LT_Updates lT_Updates = db.LT_Updates.Find(id);
            if (lT_Updates == null)
            {
                return HttpNotFound();
            }
            return View(lT_Updates);
        }

        // POST: LT_Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LT_Updates lT_Updates = db.LT_Updates.Find(id);
            db.LT_Updates.Remove(lT_Updates);
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
