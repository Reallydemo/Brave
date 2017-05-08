﻿using System;
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

            int Si = id + 1;
            int Bi = id - 1;
            var detail = NewsManage.FindDetailNews(id);
            var FindNext = NewsManage.FindDetailNews(Si);                   
            var FindBefore = NewsManage.FindDetailNews(Bi);
         
            ViewModels.Cnpagelist index = new ViewModels.Cnpagelist();
            index.FindDetailNews = detail;
            index.FindNext = FindNext;
            index.FindBefore = FindBefore;            
            return View(index);
        }
       public ActionResult ClassifyNews(int id,int ? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var classify = NewsManage.FindClassifyNews(id).OrderByDescending(p=>p.News_id).ToPagedList(pageSize, pageNumber) ;                                 
            return View(classify);
        }
    }
}