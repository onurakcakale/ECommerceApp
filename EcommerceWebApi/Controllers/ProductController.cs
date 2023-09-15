using EcommerceWebApi.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ApplicationContext appContext;

        public ProductController(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        // Get products in the all category
        [HttpGet]
        public JsonResult Get()
        {
            var query = appContext.products.Join(
                appContext.categories,
                p => p.CategoryId,
                c => c.Id, (p, c) => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = c.CategoryName,
                    CategoryId = p.CategoryId
                }).ToList();

            return new JsonResult(query);
        }

        // Get products in the selected category
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var query = appContext.products.Join(
                appContext.categories,
                p => p.CategoryId,
                c => c.Id, (p, c) => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = c.CategoryName,
                    CategoryId = p.CategoryId
                }).Where(x => x.CategoryId == id).ToList();

            return new JsonResult(query);
        }
    }
}
