using IngameDemo.Core.Context;
using IngameDemo.Core.DTOs;
using IngameDemo.Core.Models;
using IngameDemo.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngameDemoProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repository;
        public CategoryController(ApiContext context)
        {
            _repository = new CategoryRepository(context);
        }

        [HttpPost("Create")]
        public Category Add([FromBody] CategoryInput category)
        {
            var entity = new Category() {Name = category.Name, ParentCategoryId = category.ParentCategoryId, IsActive = category.IsActive };
            return _repository.Create(entity);  
        }

        [HttpPut("Update/Id")]
        public Category Update(int id, [FromBody] CategoryInput category)
        {
            var entity = new Category() { Id = id, Name = category.Name, ParentCategoryId = category.ParentCategoryId, IsActive = category.IsActive };
            return _repository.Update(entity);
        }

        [HttpDelete("Delete/Id")]
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
               

        [HttpGet("Get/Id")]
        public Category Get(int id)
        {
            return _repository.Find(id);
        }

        [HttpGet("GetAll")]
        public IEnumerable<Category> GetAll()
        {
            return _repository.FindAll();
        }

        [HttpGet("RecursiveCategory")]
        public IEnumerable<CategoryOut> RecursiveCategory()
        {
            var root = _repository.GetByParentCategoryId(null).Select(x => new CategoryOut()
            {
                Id = x.Id,
                Name = x.Name,
                Categories = _repository.GetSubCategory(x.Id).ToList()
            }).ToList();
            return root;
        }

       
    }
}
