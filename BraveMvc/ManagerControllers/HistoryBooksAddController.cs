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
    public class HistoryBooksAddController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: HistoryBooksAdd
        public ActionResult Index()
        {
            var historyBook = db.HistoryBook.Include(h => h.HistorySection);
            return View(historyBook.ToList());
        }

        // GET: HistoryBooksAdd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryBook historyBook = db.HistoryBook.Find(id);
            if (historyBook == null)
            {
                return HttpNotFound();
            }
            return View(historyBook);
        }

        // GET: HistoryBooksAdd/Create
        public ActionResult Create()
        {
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName");
            return View();
        }

        // POST: HistoryBooksAdd/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_id,Book_route,Upload_time,Section_id,Book_img,Author,Keyword,PublishTime,BookClassify_id,AuthorCountry,BookName")] HistoryBook historyBook)
        {
            if (ModelState.IsValid)
            {
                db.HistoryBook.Add(historyBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyBook.Section_id);
            return View(historyBook);
        }

        // GET: HistoryBooksAdd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryBook historyBook = db.HistoryBook.Find(id);
            if (historyBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyBook.Section_id);
            return View(historyBook);
        }

        // POST: HistoryBooksAdd/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_id,Book_route,Upload_time,Section_id,Book_img,Author,Keyword,PublishTime,BookClassify_id,AuthorCountry,BookName")] HistoryBook historyBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Section_id = new SelectList(db.HistorySection, "HistorySection_id", "HistorySectionName", historyBook.Section_id);
            return View(historyBook);
        }

        // GET: HistoryBooksAdd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryBook historyBook = db.HistoryBook.Find(id);
            if (historyBook == null)
            {
                return HttpNotFound();
            }
            return View(historyBook);
        }

        // POST: HistoryBooksAdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoryBook historyBook = db.HistoryBook.Find(id);
            db.HistoryBook.Remove(historyBook);
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
