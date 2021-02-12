using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemoProject.Core.Models
{
    public class Product:EntityBase
    {       
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string ImageUrl { get; set; }
        public  decimal Price { get; set; }      
        public string Description { get; set; }
    }
}
