using IngameDemo.Core.Models;
using IngameDemoProject.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngameDemoProject.Web.Controllers
{
    public class CategoryController : Controller
    {

        public CategoryController()
        {
        }

        [CustomAuthorize]
        public async Task<IActionResult> List()
        {
            var result = RequestHelper.GetRequest<IList<Category>>("http://localhost:5000/Category/GetAll");
            return View(result);
        }

        public ActionResult GetProductByCategoryId(int categoryId)
        {
            var result = RequestHelper.GetRequest<IList<Product>>($"http://localhost:5000/Product/GetByCategoryId/categoryId?categoryId={categoryId}");
            return Json(result);
        } 

        public ActionResult ProductDetail(int id)
        {
            var result = RequestHelper.GetRequest<Product>($"http://localhost:5000/Product/Get/Id?id={id}");
            return View(result);
        }

    }
}
