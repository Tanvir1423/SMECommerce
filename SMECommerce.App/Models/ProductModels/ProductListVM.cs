using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Models.ProductModels
{
    public class ProductListVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Item> ProductList { get; set; }
    }
}
