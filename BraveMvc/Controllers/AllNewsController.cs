using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using PagedList;
namespace BraveMvc.Controllers
{
    public class AllNewsController : Controller
    {
        // GET: AllNews
        public ActionResult Index(int?page)
        {
            var news = NewsManage.FindClassifyNews().Where(p=>p.Section_id==1).OrderByDescending(p=>p.SubmtDate);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }
    }
}