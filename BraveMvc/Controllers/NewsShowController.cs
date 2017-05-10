using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using PagedList;
using ViewModels;

namespace BraveMvc.NewsControllers
{
    public class NewsShowController : Controller
    {
        // GET: News
        
        public ActionResult Index2()
        {
            
            var xiaoxi = NewsManage.FindAllNews().OrderByDescending(p=>p.SubmtDate).Take(6);
            var CountryNews = NewsManage.FindCountryNews().Where(p => p.Section_id == 1).Take(16);
            var InternationalNews = NewsManage.FindInternationalNews().Where(p => p.Section_id == 2).Take(16);
            var HotNews = NewsManage.FindHotNews().Where(p => p.Section_id == 3).Take(16);
            ViewModels.Cnpagelist index = new ViewModels.Cnpagelist();
            index.Findcountrynews = CountryNews;
            index.FindAllNews = xiaoxi;
            index.FindInternationalNews = InternationalNews;
            index.FindHotNews = HotNews;
            return View(index);
        }
        public ActionResult Detail(int id)
        {

            var detail = NewsManage.FindDetailNews(id);                       
            var FindBefore = NewsManage.FindDetailNews(id-1);
            var FindNext = NewsManage.FindDetailNews(id + 1);                     
            ViewModels.Cnpagelist index = new ViewModels.Cnpagelist();
            index.FindDetailNews = detail;         
            index.FindBefore = FindBefore;
            index.FindNext = FindNext;                       
            return View(index);
        }
        public ActionResult Details(string keyword)
        {
            var selectnews = NewsManage.SelectNews(keyword);
            return View(selectnews);
        }
       public ActionResult ClassifyNews()
        {
            var classify = NewsManage.FindClassifyNews().Where(p => p.Section_id == 1).OrderByDescending(p => p.News_id);                                                     
            return View(classify);
        }
    }
}