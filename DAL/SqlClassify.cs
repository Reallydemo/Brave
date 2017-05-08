using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlClassify:IClassify
    {
        BraveEntities db = new BraveEntities();
        public IList<Classify> FindAllClassify()
        {
            return db.Classify.ToList();
        }
        public IQueryable findclassify(int id)
        {
            return db.Classify.Include("Goods").Where(p => p.Classify_id == id);
        }
    }
}
