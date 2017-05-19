using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlHistorySection:IHistorySection
    {
        BraveEntities db = new BraveEntities();
        public IEnumerable<HistorySection> FindAllHistory()
        {
            var data = from p in db.HistorySection select p;
            return data;
        }
    }
}
