using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace BraveMvc.ManagerControllers
{
    public class HistoryVideosAddController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: HistoryVideosAdd
        public ActionResult Index()
        {
            var historyVideo = db.HistoryVideo.Include(h => h.HistorySection);
            return View(historyVideo.ToList());
        }

        // GET: HistoryVideosAdd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryVideo historyVideo = db.HistoryVideo.Find(id);
            if (historyVideo == null)
            {
                return HttpNotFound();
            }
            return View(historyVideo);
        }

        // GET: HistoryVideosAdd/Create
        public ActionResult Create()
        {
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName");
            return View();
        }

        // POST: HistoryVideosAdd/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Video_id,Video_route,Video_date,Keyword,Video_img,Section_id,VideoClassify_id,Actor,Director,VideoCountry,VideoTime,VideoName")] HistoryVideo historyVideo)
        {
            if (ModelState.IsValid)
            {
                db.HistoryVideo.Add(historyVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyVideo.Section_id);
            return View(historyVideo);
        }

        // GET: HistoryVideosAdd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryVideo historyVideo = db.HistoryVideo.Find(id);
            if (historyVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyVideo.Section_id);
            return View(historyVideo);
        }

        // POST: HistoryVideosAdd/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Video_id,Video_route,Video_date,Keyword,Video_img,Section_id,VideoClassify_id,Actor,Director,VideoCountry,VideoTime,VideoName")] HistoryVideo historyVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyVideo.Section_id);
            return View(historyVideo);
        }

        // GET: HistoryVideosAdd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryVideo historyVideo = db.HistoryVideo.Find(id);
            if (historyVideo == null)
            {
                return HttpNotFound();
            }
            return View(historyVideo);
        }

        // POST: HistoryVideosAdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoryVideo historyVideo = db.HistoryVideo.Find(id);
            db.HistoryVideo.Remove(historyVideo);
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
