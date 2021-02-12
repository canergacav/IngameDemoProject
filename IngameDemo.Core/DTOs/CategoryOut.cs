using IngameDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.DTOs
{
    public class CategoryOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryOut> Categories { get; set; }
    }
}
