using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using IDAL;
using DALFactory;


namespace BraveMvc.Controllers
{
    public class BraveController : Controller
    {
        // GET: Brave
        public ActionResult Index()
        {
            var news= BraveManage.FindAllNews().OrderByDescending(p => p.SubmtDate).Take(4);
            var goodss = GoodsManage.FindAllBooks().OrderByDescending(p => p.Grounding).Skip(6).Take(3);
            var spots = BraveManage.FindAllSpots().OrderByDescending(p => p.RedSpotsName).Take(3);
            var share = BraveManage.FindAllShare().OrderByDescending(p => p.RedShareTime).Take(4);
            ViewModels.Brave index = new ViewModels.Brave();
            index.new1 = news;
            index.Good1 = goodss;
            index.spots1 = spots;
            index.Share = share;
            return View(index);
        }
    }
}