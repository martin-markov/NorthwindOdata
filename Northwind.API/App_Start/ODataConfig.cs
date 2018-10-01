using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.API;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;



namespace Northwind.API
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<Order_Detail>("Order Details").EntityType.HasKey(od => od.OrderID);
//            builder.EntitySet<Order_Detail>("Order Details");
            builder.EntitySet<Product>("Products");

            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Shipper>("Shippers");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());


        }
    }
}
