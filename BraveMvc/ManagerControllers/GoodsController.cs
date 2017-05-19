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
    public class GoodsController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: Goods
        public ActionResult Index()
        {
            var goods = db.Goods.Include(g => g.Classify);
            return View(goods.ToList());
        }

        // GET: Goods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            ViewBag.Classify_id = new SelectList(db.Classify, "Classify_id", "ClassifyName");
            return View();
        }

        // POST: Goods/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Goods_id,GoodsName,GoodsImage1,GoodsImage2,GoodsImage3,Grounding,Undercarriage,GoodsPrice,GoodsDes,Numbers,Classify_id,Company")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                
                db.Goods.Add(goods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classify_id = new SelectList(db.Classify, "Classify_id", "ClassifyName", goods.Classify_id);
            return View(goods);
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null) 
            {
                return HttpNotFound();
            }
            ViewBag.Classify_id = new SelectList(db.Classify, "Classify_id", "ClassifyName", goods.Classify_id);
            return View(goods);
        }

        // POST: Goods/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Goods_id,GoodsName,GoodsImage1,GoodsImage2,GoodsImage3,Grounding,Undercarriage,GoodsPrice,GoodsDes,Numbers,Classify_id,Company")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classify_id = new SelectList(db.Classify, "Classify_id", "ClassifyName", goods.Classify_id);
            return View(goods);
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goods goods = db.Goods.Find(id);
            db.Goods.Remove(goods);
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
