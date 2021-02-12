using IngameDemo.Core.Context;
using IngameDemo.Core.DTOs;
using IngameDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IngameDemo.Core.Repositories
{
    public class CategoryRepository : BasicCrudRepo<Category>
    {
        private readonly ApiContext _context;
        public CategoryRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public List<CategoryOut> GetSubCategory(int id)
        {
            List<CategoryOut> subItems = GetByParentCategoryId(id).Select(a =>
            {
                var subCategory = GetSubCategory(a.Id).ToList();
                return new CategoryOut()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Categories = subCategory.Any() ? GetSubCategory(a.Id) : null
                };
            }).ToList();
            return subItems;
        }

        //.Where(x => x.ParentCategoryId == null)

        public List<Category> GetByParentCategoryId(int? id)
        {
            return  _context.Category.Where(x => x.ParentCategoryId == id).ToList();
        }
    }
}
