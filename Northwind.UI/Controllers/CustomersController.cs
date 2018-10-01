using Northwind.UI.Models;
using Northwind.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Northwind.UI.Controllers
{
    public class CustomersController : Controller
    {
        private CustomersService _customersService;
        public CustomersService CustomersService
        {
            get
            {
                if (_customersService == null)
                    _customersService = new CustomersService();
                return _customersService;
            }
        }
        //
        // GET: /Customers/

        public async Task<ActionResult> List(string customerName = "")
        {
            CustomerListViewModel model = await this.CustomersService.GetAll(customerName);
            return View(model);
        }

        protected override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var httpContext = System.Web.HttpContext.Current;

            
        }

    }
}
