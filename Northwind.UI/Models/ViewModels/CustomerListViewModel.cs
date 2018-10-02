using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.UI.Models
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel()
        {
            this.Customers = new List<Customer>();
        }
        public IEnumerable<Customer> Customers { get; set; }
    }
}