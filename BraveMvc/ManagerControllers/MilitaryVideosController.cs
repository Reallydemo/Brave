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
    public class MilitaryVideosController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: MilitaryVideos
        public ActionResult Index()
        {
            var militaryVideo = db.MilitaryVideo.Include(m => m.ForumSection);
            return View(militaryVideo.ToList());
        }

        // GET: MilitaryVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryVideo militaryVideo = db.MilitaryVideo.Find(id);
            if (militaryVideo == null)
            {
                return HttpNotFound();
            }
            return View(militaryVideo);
        }

        // GET: MilitaryVideos/Create
        public ActionResult Create()
        {
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName");
            return View();
        }

        // POST: MilitaryVideos/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MilitaryVideo_id,MilitaryVideoName,MilitaryVideoDecride,MilitaryVideo_Ways,ForumSection_id,MilitaryVideoTime")] MilitaryVideo militaryVideo)
        {
            if (ModelState.IsValid)
            {
                db.MilitaryVideo.Add(militaryVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", militaryVideo.ForumSection_id);
            return View(militaryVideo);
        }

        // GET: MilitaryVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryVideo militaryVideo = db.MilitaryVideo.Find(id);
            if (militaryVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", militaryVideo.ForumSection_id);
            return View(militaryVideo);
        }

        // POST: MilitaryVideos/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MilitaryVideo_id,MilitaryVideoName,MilitaryVideoDecride,MilitaryVideo_Ways,ForumSection_id,MilitaryVideoTime")] MilitaryVideo militaryVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(militaryVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", militaryVideo.ForumSection_id);
            return View(militaryVideo);
        }

        // GET: MilitaryVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryVideo militaryVideo = db.MilitaryVideo.Find(id);
            if (militaryVideo == null)
            {
                return HttpNotFound();
            }
            return View(militaryVideo);
        }

        // POST: MilitaryVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MilitaryVideo militaryVideo = db.MilitaryVideo.Find(id);
            db.MilitaryVideo.Remove(militaryVideo);
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
