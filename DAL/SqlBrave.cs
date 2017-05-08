using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
   public  class SqlBrave:IBrave
    {

        BraveEntities db = new BraveEntities();
        public IEnumerable<News> FindAllNews()
        {
            return db.News.ToList();
        }
        public IEnumerable<RedSpots> FindAllSpots()
        {
            return db.RedSpots.ToList();
        }
        public IEnumerable<RedShare> FindAllShare()
        {
            return db.RedShare.ToList();
        }
    }
}
