using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class NewsManage
    {
        public static INews news = DataAccess.CreatNews();
        public static IEnumerable<News> FindAllNews()
        {
            return news.FindAllNews();
        }
        public static IEnumerable<News> FindCountryNews()
        {
            return news.FindCountryNews();
        }
        public static IEnumerable<News> FindInternationalNews()
        {
            return news.FindInternationalNews();
        }
        public static IEnumerable<News> FindHotNews()
        {
            return news.FindHotNews();
        }
        public static News FindDetailNews(int id)
        {
            return news.FindDetailNews(id);
        }
        public static IEnumerable<News> FindClassifyNews(int id)
        {
            return news.FindClassifyNews(id);
        }
    }
}
