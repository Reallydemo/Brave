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
   public class BraveManage
    {

        public static IBrave brave = DataAccess.Createbrave();
        public static IEnumerable<News> FindAllNews()
        {
            return brave.FindAllNews();
        }
        public static IEnumerable<RedSpots> FindAllSpots()
        {
            return brave.FindAllSpots();
        }
        public static IEnumerable<RedShare> FindAllShare()
        {
            return brave.FindAllShare();
        }
    }
}
