using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using BLL;
using System.Net;
using Models;
using DAL;
using IDAL;
using DALFactory;
using ViewModels;
using System.Data.Entity.Validation;



namespace BraveMvc.Controllers
{
  
    public class MallsController : Controller
    {
        // GET: Malls
       
        public ActionResult Index()
        {
            var good=GoodsManage.FindAllBooks().OrderByDescending(p => p.Grounding).Take(8);
            var Zhanji = GoodsManage.FindAllBooks().Where(b => b.Classify_id == 1).Take(6);
            var Qiang = GoodsManage.FindAllBooks().Where(c => c.Classify_id == 4).Take(12);
            var Hangmu = GoodsManage.FindAllBooks().Where(a => a.Classify_id == 3).Take(6);
            var Feixing = GoodsManage.FindAllBooks().Where(d => d.Classify_id == 2).Take(6);
            var Tanke = GoodsManage.FindAllBooks().Where(e => e.Classify_id == 8).Take(6);
         
            ViewModels.Goodss index = new ViewModels.Goodss();
            index.Good6 = good;
            index.Good1 = Zhanji;
            index.Good2 = Qiang;
            index.Good3 = Hangmu;
            index.Good4 = Feixing;
            index.Good5 = Tanke; 


            return View(index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult aboutss()
        {
            return View();
        }
      
        public ActionResult Classify(String classifyInfoFrom, String SortInfoFrom, string currentFilter, int page=1)
        {
            var clas = ClassifyManage.FindAllClassify();
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

            if (!String.IsNullOrEmpty(classifyInfoFrom))
            {

                goods = goods.Where(x => x.Classify.ClassifyName == classifyInfoFrom);

            }
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                if (SortInfoFrom == "价格降序")
                {
                    goods = goods.OrderByDescending(p => p.GoodsPrice);
                }
                else if(SortInfoFrom == "价格升序")
                {
                    goods = goods.OrderBy(p => p.GoodsPrice);
                }
                
                else if (SortInfoFrom == "更新时间")
                {
                    goods = goods.OrderByDescending(p => p.Grounding);
                }
              

            }

            const int pageSize = 10;

            ViewModels.Clasaifymenu clmenu = new ViewModels.Clasaifymenu();
            clmenu.Classify1 = clas;
            clmenu.Goodsss = goods.ToPagedList(page, pageSize);
         


            return View("Classify", clmenu);
        }
        //详情
        public ActionResult Detail(int id,int classid)
        {

            var good = GoodsManage.Getgood(id);
            var classif = GoodsManage.FindAllBooks().Where(p => p.Classify_id == classid);
            var Comment = CommentGoodsManage.findallcomment(id);
        
            if (good == null)
            {
                return HttpNotFound();
            }
            if (classif == null)
            {
                return HttpNotFound();
            }
            if (Comment == null)
            {
                return HttpNotFound();
            }
            ViewModels.GoodsDetail index = new GoodsDetail();
            index.Goodss = good;
            index.Goods11 = classif;
            index.Comment1 = Comment;
          
            return View(index);
            //return View();
        }
        [HttpPost]
        public ActionResult addComment(CommentGoods comgoods)
        {
            string content = Request["detail-goods-comment"];
            int goodsid = int.Parse(Request["detail-goodsName"].ToString());
            int userid = int.Parse(Session["User_id"].ToString());
            if (content == null||content.Length==0)
            {
                return Content("<script>;alert('评论内容不能为空!');history.go(-1)</script>");
            }
            else if (ModelState.IsValid)
              {
                    comgoods.User_id = userid;
                    comgoods.Goods_id = goodsid;
                    comgoods.Content = content;
                    comgoods.CommentTime = DateTime.Now;
                    CommentGoodsManage.AddCommentGoods(comgoods);
                    return Content("<script>;alert('评论成功!');window.location.href='/Malls/Detail'</script>");
               }
           
          
            return RedirectToAction("Detail", "Malls");


        }
        public ActionResult Reply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reply(ReplyGoods repgoods)
        {
            string reply = Request["replaygoods"];
            int commid = Convert.ToInt32(Request["commendid"]);
            int userid = Convert.ToInt32(Session["User_id"]);
            var replylist = CommentGoodsManage.findallreply(commid);
            if (reply == null)
            {
                return Content("<script>;alert('回复内容不能为空!');history.go(-1)</script>");
            }
            else if (ModelState.IsValid)
            {
                repgoods.CommentGoods_id = commid;
                repgoods.User_id = userid;
                repgoods.Content = reply;
                repgoods.ReplyTime = DateTime.Now;
                CommentGoodsManage.addReplyGoods(repgoods);
                return Content("<script>;alert('回复成功!');window.location.href='/Malls/Detail'</script>");
            }
                return RedirectToAction("Detail", "Malls");
        }
      
        public ActionResult SelectReply(int commendid)
        {
            var replydf = CommentGoodsManage.findallreply(commendid);
            ViewModels.GoodsDetail der = new GoodsDetail();
            der.Reply1 = replydf;
            return View(der);
        }


        public ActionResult selectGood(string searchString,string SortInfoFrom)
        {
            var good = GoodsManage.selectGoods();
            var tugood = GoodsManage.FindGoods().Take(3);
            if (!String.IsNullOrEmpty(searchString))
            {
                good = good.Where(s => s.GoodsDes.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                if (SortInfoFrom == "价格降序")
                {
                    good = good.OrderByDescending(p => p.GoodsPrice);
                }
                else if (SortInfoFrom == "价格升序")
                {
                    good = good.OrderBy(p => p.GoodsPrice);
                }

                else if (SortInfoFrom == "更新时间")
                {
                    good = good.OrderByDescending(p => p.Grounding);
                }

            }
                SelectGoods inde = new SelectGoods();
            inde.good1 = good;
            inde.good2 = tugood;
            return View(inde);
        }
    }
}