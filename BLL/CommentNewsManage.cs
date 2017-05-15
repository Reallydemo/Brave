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
   public class CommentNewsManage
    {
        public static ICommentNews icommentnews = DataAccess.Createcommentnews();
        public static void AddCommentNews(CommentNews commentnews)
        {
            icommentnews.AddCommentNews(commentnews);
        }
    }
}
