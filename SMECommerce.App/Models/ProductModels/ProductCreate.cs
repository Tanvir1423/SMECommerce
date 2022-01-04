using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Models.ProductModels
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ManufactureDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<Category> categoryList { get; set; }
    }
}
