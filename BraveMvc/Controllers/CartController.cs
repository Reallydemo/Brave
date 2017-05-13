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
        [HttpPost]
        public ActionResult updatecart(int cartid)
        {
            var cartss = CartManage.findcartid(cartid);
            var count = int.Parse(Request["text_box"].ToString());
            cartss.CartCount = count;
            cartss.Total = decimal.Parse((count * cartss.Price).ToString());
            CartManage.Update(cartss);
            //return Content("Index","Cart");
            return RedirectToAction("Index", "Cart");

        }
        public ActionResult delete(int id)
        {
            CartManage.Delete(id);
            return RedirectToAction("Index", "Cart");
        }
        List<Cart> Carts
        {
            get
            {
                if (Session["Carts"] == null)
                {
                    Session["Carts"] = new List<Cart>();
                }
                return (Session["Carts"] as List<Cart>);
            }
            set { Session["Cart"] = value; }
        }
        [HttpPost]
      public ActionResult updatetotal(FormCollection formCol)
        {
            var useid = int.Parse(Session["User_id"].ToString());
            var Carts = CartManage.Findusercart(useid);
            var alltotal =formCol["all-total"];
            var dsdwe =Convert.ToInt32(alltotal);
            if (dsdwe < 1)
            {
                return Content("<script>;alert('请选择商品');history.go(-1)");
            }
            else
            {
                foreach (var item in Carts)
                {
                    var jisuan = Carts.FirstOrDefault(p => p.Cart_id == item.Cart_id);
                    if (jisuan != null)
                    {
                        var chk = Request.Form["checked_goods"];

                        if (chk != null)
                        {

                            jisuan.Flog = true;
                            CartManage.Update(jisuan);
                        }
                        else
                        {
                            jisuan.Flog = false;
                            CartManage.Update(jisuan);
                        }



                    }
                }
            }

            return RedirectToAction("Address", "Cart");

        }
      

        public ActionResult Address()
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            var adduse = AddressManage.seuseadd(userid);
            MallsCart ind = new MallsCart();
            ind.Address1 = adduse;
            return View(ind);

        }
        [HttpPost]
      public ActionResult Address(Address addre)
        {
            int  userid = Convert.ToInt32(Session["User_id"]);
            string name = Request["address_name"];
            string dizhi = Request["address_weizi"];
            int code = Convert.ToInt32(Request["address_code"]);
            string phone =Request["address_phone"];
            addre.User_id = userid;
            addre.AddressName = name;
            addre.AddressDe = dizhi;
            addre.AddressCode =code;
            addre.Addressphone = phone;
            AddressManage.Addaddre(addre);
            return Content("<script>;alert('提交成功');history.go(-1)</script>");
        }
        public ActionResult seleadrd(int id)
        {
           
            var cde = AddressManage.selectaddid(id);
            if (cde.flat != true)
            {
                int userid = Convert.ToInt32(Session["User_id"]);
                var sfdd = AddressManage.selectaaduse(userid);
                if (sfdd!=null)
                {
                    sfdd.flat = false;
                    AddressManage.update(sfdd);
                }
               
                cde.flat = true;
                AddressManage.update(cde);
            }

            
            return View("Address");
        }
        public ActionResult deleteaddre(int id)
        {
            AddressManage.delete(id);
            return RedirectToAction("Address", "Cart");
        }
        
    }
}