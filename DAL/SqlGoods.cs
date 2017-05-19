using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlGoods:IGoods
    {
        BraveEntities db = new BraveEntities();
        public IList<Goods> FindAllBooks()
        {
            return db.Goods.ToList();
        }
     
        public IQueryable<Goods> FindGoods()
        {
            return from m in db.Goods.OrderBy(p => p.Grounding)

                   select m;
        }
        public Goods Getgood(int id)
        {
            return db.Goods.Include("Classify").Single(b => b.Goods_id == id);
        }
        public void Deletegood(int id)
        {
            var so = db.Cart.Include("Goods").Where(l => l.Goods_id == id);
            foreach(var item in so)
            {
                if (item != null)
                {
                    db.Cart.Remove(item);

                }
            }
            Goods good = db.Goods.Single(o => o.Goods_id == id);
            db.Goods.Remove(good);
            db.SaveChanges();
          
        }
        public void Updategood(Goods goods)
        {
            db.Entry<Goods>(goods).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
           
        }
        public void AddToGoods(Goods goods)
        {
            db.Goods.Add(goods);
            db.SaveChanges();
           
        }
        public IList<Classify> GetallClassify()
        {
            return db.Classify.ToList();
        }
        public IQueryable<Goods> selectGoods()
        {
           return from n in db.Goods select n;
        }


    }
}
