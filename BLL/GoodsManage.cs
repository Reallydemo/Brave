using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using DAL;
using Models;

namespace BLL
{
   public class GoodsManage
    {
       public static IGoods good = DataAccess.Creategood();
        public static IList<Goods> FindAllBooks()
        {
            return good.FindAllBooks();
        }
        public static IQueryable<Goods> FindGoods()
        {
            return good.FindGoods();
        }
        public static Goods Getgood(int id)
        {
            return good.Getgood(id);
        }
        public static void Deletegood(int id)
        {
            good.Deletegood(id);
            

        }
        public static void Updategood(Goods goods)
        {
            good.Updategood(goods);

        }
        public static void AddToGoods(Goods goods)
        {
            good.AddToGoods(goods);

        }
        public static IList<Classify> GetallClassify()
        {
            return good.GetallClassify();
        }
        public static IQueryable<Goods> selectGoods()
        {
            return good.selectGoods();
        }
    }
}
