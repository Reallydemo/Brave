using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using IDAL;
using DALFactory;
using ViewModels;


namespace BraveMvc.Controllers
{
    public class AllGoodsController : Controller
    {
        // GET: AllGoods
        public ActionResult Index(String classifyInfoFrom, String SortInfoFrom, string currentFilter, int? page)
        {
           

        

            var goods = GoodsManage.FindGoods();

            if (classifyInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                classifyInfoFrom = currentFilter;
            }

            ViewBag.CurrentFilter = classifyInfoFrom;
            if (SortInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                SortInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = SortInfoFrom;

            if (!string.IsNullOrEmpty(classifyInfoFrom))  //注意，判断字符串类型为空，要使用String.IsNullEmpty() 而不能使用 !=null 来判断。
            {
                goods = goods.Where(x => x.Classify.ClassifyName == classifyInfoFrom);
            }
            //ViewBag.searchString = searchString;
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                if (SortInfoFrom == "价格降序")
                {
                    goods = goods.OrderByDescending(p => p.GoodsPrice);
                }
                else if (SortInfoFrom == "价格升序")
                {
                    goods = goods.OrderBy(p => p.GoodsPrice);
                }
                else if (SortInfoFrom == "更新时间")
                {
                    goods = goods.OrderByDescending(p => p.Grounding);
                }


            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);

            return View(goods.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Classify(String classifyInfoFrom, String SortInfoFrom, string currentFilter, int? page)
        {
            var clas = ClassifyManage.FindAllClassify();
            var goods = GoodsManage.FindGoods();
            if (page == null)
            {
                page = 1;
            }
            if (classifyInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                classifyInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = classifyInfoFrom;
            if (SortInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                SortInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = SortInfoFrom;

            if (!String.IsNullOrEmpty(classifyInfoFrom))
            {

                goods = goods.Where(x => x.Classify.ClassifyName == classifyInfoFrom);

            }
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                goods = goods.OrderByDescending(p => p.GoodsPrice);
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            ViewModels.Clasaifymenu clmenu = new ViewModels.Clasaifymenu();
            clmenu.Classify1 = clas;
            clmenu.Goodsss = goods.ToPagedList(pageSize, pageNumber);

            return View("Classify", clmenu);
          
        }
    }
}