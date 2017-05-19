using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace BraveMvc.ManagerControllers
{
    public class ForaController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: Fora
        public async Task<ActionResult> Index()
        {
            var forum = db.Forum.Include(f => f.ForumSection).Include(f => f.Users);
            return View(await forum.ToListAsync());
        }

        // GET: Fora/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = await db.Forum.FindAsync(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: Fora/Create
        public ActionResult Create()
        {
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName");
            ViewBag.User_id = new SelectList(db.Users, "User_id", "UserAccount");
            return View();
        }

        // POST: Fora/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Forum_id,ForumTopic,ForumContent,ForumTime,User_id,ForumSection_id,ForumImage,ForumClicks")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Forum.Add(forum);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", forum.ForumSection_id);
            ViewBag.User_id = new SelectList(db.Users, "User_id", "UserAccount", forum.User_id);
            return View(forum);
        }

        // GET: Fora/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = await db.Forum.FindAsync(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", forum.ForumSection_id);
            ViewBag.User_id = new SelectList(db.Users, "User_id", "UserAccount", forum.User_id);
            return View(forum);
        }

        // POST: Fora/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Forum_id,ForumTopic,ForumContent,ForumTime,User_id,ForumSection_id,ForumImage,ForumClicks")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ForumSection_id = new SelectList(db.ForumSection, "ForumSection_id", "ForumSectionName", forum.ForumSection_id);
            ViewBag.User_id = new SelectList(db.Users, "User_id", "UserAccount", forum.User_id);
            return View(forum);
        }

        // GET: Fora/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = await db.Forum.FindAsync(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Fora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum forum = await db.Forum.FindAsync(id);
            db.Forum.Remove(forum);
            await db.SaveChangesAsync();
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
