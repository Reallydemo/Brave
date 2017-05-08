using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ICart
    {
      
        IList<Cart> Findusercart(int id);
       int Findgoodscart(int userid,int goodsid);
        Cart findsusergoodcart(int userid, int goodsid);
        void AddCart(Cart carts);
        //Cart getCart(int id);
        //void Delete(int id);
        void Update(Cart carts);

    }
}
