using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace ViewModels
{
    public class Cnpagelist
    {
        public IEnumerable<News> Findcountrynews { get;set; }
        public IEnumerable<News> FindAllNews { get; set; }
        public IEnumerable<News> FindInternationalNews { get; set; }
        public IEnumerable<News> FindHotNews { get; set; }
        public News FindDetailNews {get; set;}
        public News FindNext { get; set; }
        public News FindBefore { get; set; }
        public IEnumerable<News> FindClassifyNews { get; set; }
        public IEnumerable<News> SelectNews { get; set; }   
       
     
    }
}