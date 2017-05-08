using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class Brave
    {
        public IEnumerable<RedSpots> spots1 { get; set; }
        public IEnumerable<Goods> Good1 { get; set; }
        public IEnumerable<News> new1 { get; set; }
        public IEnumerable<RedShare> Share { get; set; }
    }
}