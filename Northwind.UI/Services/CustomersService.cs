using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Northwind.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Simple.OData.Client;


namespace Northwind.UI.Services
{
    public class CustomersService
    {
        public CustomersService()
        {

        }

        internal async Task<CustomerListViewModel> GetAll(string customerName)
        {
            CustomerListViewModel vm = new CustomerListViewModel();
            //string host = "http://localhost:63927/";
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(host);
            //    string endPoint = "odata/Customers?$expand=Orders($select=OrderID)";
            //    if (!String.IsNullOrEmpty(customerName))
            //        endPoint = String.Concat(endPoint, String.Format("&$filter=contains(ContactName, '{0}')", customerName));
            //    HttpResponseMessage response = await client.GetAsync(endPoint).ConfigureAwait(false);
            //    string content = await response.Content.ReadAsStringAsync();
            //    //dynamic customers = JObject.Parse(content);
            //    vm.Customers = JsonConvert.DeserializeObject<ODataResponse<Customer>>(content).Value ?? Enumerable.Empty<Customer>();

            //}
            string host = "http://localhost:63927";
            ODataClient client = new ODataClient(host);
            //vm.Customers = await client.For<Customer>().Expand(x=>x.Orders).Select(x=> new {x.CustomerID , x.ContactName, Orders = x.Orders.Select(o=>o.OrderID)}).FindEntriesAsync();
            var a = await client.For<Customer>().FindEntriesAsync();
            
            return vm;
        }

        internal CustomerViewModel GetCustomerDetails(string customerID)
        {
            CustomerViewModel vm = new CustomerViewModel();
            string host = "http://localhost:63927/";
            ODataClient client = new ODataClient(host);


            return vm;
        }
    }
}