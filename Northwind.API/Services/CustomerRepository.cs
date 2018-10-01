using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Northwind.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindContext db = null;

        public CustomerRepository()
        {
            this.db = new NorthwindContext();
        }

        //dependecy injection
        public CustomerRepository(NorthwindContext db)
        {
            this.db = db;
        }

        public IQueryable<Customer> GetAll()
        {
            return db.Customers;
        }
        public IQueryable<Customer> GetById(string id)
        {
            return db.Customers.Where(c => c.CustomerID.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IQueryable<Order> GetOrders(string customerId)
        {
            return db.Customers.Where(m => m.CustomerID.Equals(customerId, StringComparison.InvariantCultureIgnoreCase)).SelectMany(m => m.Orders);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}