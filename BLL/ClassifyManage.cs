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
   public class ClassifyManage
    {
        public static IClassify clas = DataAccess.Createclassify();
        public static IList<Classify> FindAllClassify()
        {
            return clas.FindAllClassify();
        }
        public static IQueryable findclassify(int id)
        {
            return clas.findclassify(id);
        }
    }
}
