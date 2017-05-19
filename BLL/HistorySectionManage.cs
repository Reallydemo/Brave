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
    public class HistorySectionManage
    {
        public static IHistorySection historysection = DataAccess.CreateHistorySection();
        public static IEnumerable<HistorySection>  FindAllHistory()
        {
            return historysection.FindAllHistory();
        }
    }
}
