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
    public class HistoriesAddController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: HistoriesAdd
        public ActionResult Index()
        {
            var history = db.History.Include(h => h.HistorySection);
            return View(history.ToList());
        }

        // GET: HistoriesAdd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.History.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // GET: HistoriesAdd/Create
        public ActionResult Create()
        {
            ViewBag.HistorySection_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName");
            return View();
        }

        // POST: HistoriesAdd/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]     
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "History_id,HistoryTopic,HistoryContent,HistoryTime,HistorySection_id,HistoryPicture,HistoryClassify_id")] History history)
        {
            if (ModelState.IsValid)
            {
                db.History.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HistorySection_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", history.HistorySection_id);
            return View(history);
        }

        // GET: HistoriesAdd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.History.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            ViewBag.HistorySection_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", history.HistorySection_id);
            return View(history);
        }

        // POST: HistoriesAdd/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "History_id,HistoryTopic,HistoryContent,HistoryTime,HistorySection_id,HistoryPicture,HistoryClassify_id")] History history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HistorySection_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", history.HistorySection_id);
            return View(history);
        }

        // GET: HistoriesAdd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.History.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // POST: HistoriesAdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            History history = db.History.Find(id);
            db.History.Remove(history);
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
