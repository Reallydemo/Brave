using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using IDAL;
using DALFactory;

namespace BLL
{
  public class CartManage
    {
        public static ICart cartss = DataAccess.CreateCart();
      
        public static void AddCart(Cart carts)
        {
          cartss.AddCart(carts);
        }
        public static IList<Cart> Findusercart(int id)
        {
            return cartss.Findusercart(id);
        }
        public static int Findgoodscart(int userid, int goodsid)
        {
           return cartss.Findgoodscart(userid,goodsid);
        }
        public static Cart findcartid(int cartid)
        {
            return cartss.findcartid(cartid);
        }
        public static Cart findsusergoodcart(int userid, int goodsid)
        {
            return cartss.findsusergoodcart(userid, goodsid);
        }
        public static void Update(Cart carts)
        {
            cartss.Update(carts);
        }
        public static void Delete(int id)
        {
            cartss.Delete(id);
        }
        public static void AddOrder(Order order)
        {
            cartss.AddOrder(order);
        }
    }
}
