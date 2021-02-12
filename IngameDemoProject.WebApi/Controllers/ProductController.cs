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
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepo;
        
        public ProductController(ApiContext context)
        {
            _productRepo = new ProductRepository(context);
            
        }

        [HttpPost("Create")]
        public Product Add([FromBody] ProductInput product)
        {
            var entity = new Product() { Name = product.Name, CategoryId = product.CategoryId, Description = product.Description, ImageUrl = product.ImageUrl, Price = product.Price, IsActive = product.IsActive };
            return _productRepo.Create(entity);
        }

        [HttpPut("Update/Id")]
        public Product Update(int id, [FromBody] ProductInput product)
        {
            var entity = new Product() { Id = id, Name = product.Name, CategoryId = product.CategoryId, Description = product.Description, ImageUrl = product.ImageUrl, Price = product.Price, IsActive = product.IsActive };
            return _productRepo.Update(entity);
        }

        [HttpDelete("Delete/Id")]
        public bool Delete(int id)
        {
            return _productRepo.Delete(id);
        }


        [HttpGet("Get/Id")]
        public Product Get(int id)
        {
            return _productRepo.Find(id);
        }

        [HttpGet("GetAll")]
        public IEnumerable<Product> GetAll()
        {
            return _productRepo.FindAll();
        }

        [HttpGet("GetByCategoryId/categoryId")]
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _productRepo.GetByCategoryId(categoryId);
        }
    }
}
