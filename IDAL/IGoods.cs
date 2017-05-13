using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IGoods
    {
        IList<Goods> FindAllBooks();
        IQueryable<Goods> FindGoods();
        Goods Getgood(int id);

        void Deletegood(int id);

        void Updategood(Goods goods);

        void AddToGoods(Goods goods);
        IList<Classify> GetallClassify();
        IQueryable<Goods> selectGoods();
             
    }
}
