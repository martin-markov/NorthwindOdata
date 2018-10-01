using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.API.Services
{
    public interface ICustomerRepository : IDisposable 
    {
        IQueryable<Customer> GetAll();
        IQueryable<Customer> GetById(string id);
        IQueryable<Order> GetOrders(string customerId);
    }
}
