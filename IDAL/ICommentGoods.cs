using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface ICommentGoods
    {
        void AddCommentGoods(CommentGoods comgood);
        IList<CommentGoods> findallcomment(int id);
        void addReplyGoods(ReplyGoods repgood);
        IList<ReplyGoods> findallreply(int id);
    }
}
