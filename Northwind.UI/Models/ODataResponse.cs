using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.UI.Models
{
    internal class ODataResponse<T>
    {
        public List<T> Value { get; set; }
    }
}