using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlCommentNews:ICommentNews
    {
        BraveEntities db = new BraveEntities();
        public void AddCommentNews(CommentNews commentnews)
        {
            db.CommentNews.Add(commentnews);
            db.SaveChanges();
        }
    }
}
