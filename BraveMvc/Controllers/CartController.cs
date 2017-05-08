using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using BLL;
using Models;
using ViewModels;

namespace BraveMvc.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var carts = CartManage.Findusercart(userid);
            MallsCart inde = new MallsCart();
            inde.Carts1 = carts;

            return View(inde);
        }
        // GET: Cart
        [HttpPost]
        public ActionResult AddCart(Cart carts)
        {
            int goodid =int.Parse( Request["goodsid"]);
            decimal price = decimal.Parse(Request["price"].ToString());
            int userid = int.Parse(Session["User_id"].ToString());
            int num = int.Parse(Request["Jm_Amount"]);
            var goodscart = CartManage.Findgoodscart(userid, goodid);
            try
            {
                if (goodscart >=1)
                {
                    var usergoods = CartManage.findsusergoodcart(userid, goodid);
                    usergoods.CartCount = usergoods.CartCount+num;
                    usergoods.Total = price * usergoods.CartCount;
                    CartManage.Update(usergoods);
                    return Content("<script>;alert('添加成功');window.location.href='/Malls/Detail'</script>");
                }
                else
                {
                    carts.User_id = userid;
                    carts.Goods_id = goodid;
                    carts.Price = price;
                    carts.CartCount = num;
                    carts.Total = price * num;
                    CartManage.AddCart(carts);
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
               
            }
            catch (DbEntityValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}