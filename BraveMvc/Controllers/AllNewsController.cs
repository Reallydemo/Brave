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
        public ActionResult Index(string current,int?page)
        {
            var news = NewsManage.FindClassifyNews().Where(p=>p.Section_id==1).OrderByDescending(p=>p.News_id);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageSize,pageNumber));
        }
    }
}