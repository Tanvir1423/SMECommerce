using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Models.ProductModels
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public DateTime ManufactureDate { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<Category> categoryList { get; set; }
    }
}
