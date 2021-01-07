using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class ProductChartViewModel
    {
        public IEnumerable<ProductChart> values { get; set; }
    }
}