using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class Paging
    {
        private BraveEntities _Context = new BraveEntities();
        //获取总页数
        public int GetPageCount(int pageSize)
        {
            int rowsCount = _Context.Goods.Count();
            int pageCount = (int)Math.Ceiling(1.0 * rowsCount / pageSize);//取天花板数
            return pageCount;
        }
        //获取指定页数据
        public IList<Goods> Select(int PageSize, int PageNo)
        {
          
            var query = _Context.Goods.OrderByDescending(p=>p.Grounding).Skip(PageSize * (PageNo - 1)).Take(PageSize);
            return query.ToList();
        }
    }
}