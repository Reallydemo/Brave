using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class SelectGoods
    {
        public IEnumerable<Goods> good1 { get; set; }
        public IEnumerable<Goods> good2 { get; set; }
    }
}