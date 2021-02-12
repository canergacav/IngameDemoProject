using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IngameDemo.Core.Models
{
    public class Product:EntityBase
    {       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string ImageUrl { get; set; }
        public  decimal Price { get; set; }      
        public string Description { get; set; }
    }
}
