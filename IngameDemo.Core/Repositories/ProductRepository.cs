using IngameDemo.Core.Context;
using IngameDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IngameDemo.Core.Repositories
{
    public class ProductRepository : BasicCrudRepo<Product>
    {
        private readonly ApiContext _context;
        public ProductRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _context.Product.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
