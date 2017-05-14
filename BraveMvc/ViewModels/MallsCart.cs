using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class MallsCart
    {
        public IEnumerable<Cart> Carts1 { get; set; }
        public IEnumerable<Cart> Carts2 { get; set; }
        public IEnumerable<Address> Address1 { get; set; }
        public Address Address2 { get; set; }
    }
}