using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebApplication.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}