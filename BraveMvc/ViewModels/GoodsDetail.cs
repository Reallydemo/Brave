using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class GoodsDetail
    {
        public Goods Goodss { get; set; }
        public IEnumerable<Goods> Goods11 { get; set; } 
        public IEnumerable<CommentGoods> Comment1 { get; set; }
        public IEnumerable<ReplyGoods> Reply1 { get; set; }
    }
}