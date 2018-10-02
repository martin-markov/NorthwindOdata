using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Northwind.API;
using Northwind.API.Services;
using Microsoft.AspNet.OData;

namespace Northwind.API.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Northwind.API;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers");
    builder.EntitySet<Order>("Order"); 
    builder.EntitySet<CustomerDemographic>("CustomerDemographic"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CustomersController : ODataController
    {

        private ICustomerRepository _repo;

        public CustomersController()
        {
            _repo = new CustomerRepository();
        }

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        // GET odata/Customers
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Customer> GetCustomers()
        {
            return _repo.GetAll();
        }

        // GET odata/Customers(5)
        [EnableQuery(MaxExpansionDepth=5)]
        public SingleResult<Customer> GetCustomer([FromODataUri] string key)
        {
            return SingleResult.Create(_repo.GetById(key));
        }

        // GET odata/Customers(5)/Orders
        [EnableQuery]
        public IQueryable<Order> GetOrders([FromODataUri] string key)
        {
            return _repo.GetOrders(key);
        }
    }
}
