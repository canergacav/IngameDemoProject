using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.Models
{
   public class Category:EntityBase
    {        
        public int? ParentCategoryId { get; set; }      
        public virtual IList<Product> Products { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
