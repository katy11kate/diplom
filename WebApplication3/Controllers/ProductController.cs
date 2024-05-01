using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        [Route("/product")]
        [HttpGet]
        public ActionResult<List<ProductDTO>> list1()
        {
            var groupings = Database.Context.Products.GroupBy(p => p.NameProduct).ToList();
            var response = new List<ProductDTO>();

            foreach (var group in groupings)
            {
                var productDTO = ProductDTO.ProductResponseConverter(group.ToList()[0]);

                response.Add(productDTO);
            }

            return Ok(response);
        }

        [Route("/product/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetDetails(int id)
        {
            using var ctx = new ProjectContext();

            var candidate = await ctx.Products.Where(p => p.IdProduct == id).FirstOrDefaultAsync();

            if (candidate == null)
            {
                return NotFound();
            }

            return ProductDTO.ProductResponseConverter(candidate);
        }

        [Route("/product/search/{query}")]
        [HttpGet]
        public ActionResult<List<ProductDTO>> GetSearchedProducts(string query)
        {
            var groupings = Database.Context.Products.Where(p => p.NameProduct.ToLower().Contains(query.ToLower())).GroupBy(p => p.NameProduct).ToList();
            var response = new List<ProductDTO>();

            foreach (var group in groupings)
            {
                response.Add(ProductDTO.ProductResponseConverter(group.ToList()[0]));
            }

            return Ok(response);
        }

        [Route("/product/color")]
        [HttpGet]
        public ActionResult<List<string>> list2(string name)
        {
            var colors = Database.Context.Products.Where(x=>x.NameProduct==name).GroupBy(p => p.Color).Select(x => x.ToList()[0].Color).ToList();
            
            return Ok(colors);
        }

        [Route("/product/size")]
        [HttpGet]
        public ActionResult<List<string>> listsize(string name)
        {
            var sizes = Database.Context.Products.Where(x => x.NameProduct == name).Select(p => p.Size).Distinct().ToList();

            return Ok(sizes);
        }
    }
}
