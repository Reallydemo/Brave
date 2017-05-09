using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlNews : INews
    {
        BraveEntities db = new BraveEntities();
        public IEnumerable<News> FindAllNews()
        {
            var data = from p in db.News select p;
            return data;
        }
        public IEnumerable<News> FindCountryNews()
        {
            var data = from p in db.News select p;
            return data;
        }
        public IEnumerable<News> FindInternationalNews()
        {
            var data = from p in db.News select p;
            return data;
        }
        public IEnumerable<News> FindHotNews()
        {
            var data = from p in db.News select p;
            return data;
        }
        public News FindDetailNews(int id)
        {
            var data = db.News.Find(id);
            return data;
        }
        public IEnumerable<News> FindClassifyNews()
        {
            var data = db.News;
            return data;
        }
    }



}
