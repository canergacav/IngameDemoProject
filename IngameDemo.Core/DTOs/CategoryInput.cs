using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.DTOs
{
    public class CategoryInput
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
