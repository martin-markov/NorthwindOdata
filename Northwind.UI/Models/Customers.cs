using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.UI.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public int OrderCount { get { return Orders.Count; } }
 
        public ICollection<Order> Orders { get; set; }
    }
}