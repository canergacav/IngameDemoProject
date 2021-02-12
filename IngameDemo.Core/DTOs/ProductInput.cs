using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.DTOs
{
    public class ProductInput
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
