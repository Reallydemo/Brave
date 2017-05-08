using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlCommentGoods:ICommentGoods
    {
        BraveEntities db = new BraveEntities();
        public void AddCommentGoods(CommentGoods comgood)
        {
            db.CommentGoods.Add(comgood);
            db.SaveChanges();
        }
        public IList<CommentGoods> findallcomment(int id)
        { 
            return db.CommentGoods.Include("Users").Where(p => p.Goods_id == id).ToList();
        }
        public void addReplyGoods(ReplyGoods repgood)
        {
            db.ReplyGoods.Add(repgood);
            db.SaveChanges();
        }
        public IList<ReplyGoods> findallreply(int id)
        {
            return db.ReplyGoods.Include("Users").Where(p => p.CommentGoods_id == id).ToList();
        }
    }
}
