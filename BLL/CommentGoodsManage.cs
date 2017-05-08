using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;

namespace BLL
{
  public  class CommentGoodsManage
    {
        public static ICommentGoods commgood = DataAccess.CreateCommgood();
        public static void AddCommentGoods(CommentGoods comgood)
        {
            commgood.AddCommentGoods(comgood);
        }
        public static IList<CommentGoods> findallcomment(int id)
        {
            return commgood.findallcomment(id);
        }
        public static void addReplyGoods(ReplyGoods repgood)
        {
            commgood.addReplyGoods(repgood);
        }
        public static IList<ReplyGoods> findallreply(int id)
        {
            return commgood.findallreply(id);
        }
    }
}
