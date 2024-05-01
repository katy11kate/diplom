using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class BasketController : Controller
    {
        [HttpPost]
        [Route("/basket")]
        public async Task<ActionResult<List<ProductDTO>>> GetBasketItems(int userId)
        {
            var basketItems =
                Database.Context.Baskets
                .Where(item => item.IdCustomer == userId).ToList();

            var dtos = new List<ProductDTO>();

            foreach (var product in basketItems)
            {
                dtos.Add(ProductDTO.ProductResponseConverter(product.IdProductNavigation));
            }

            basketItems.ToList();

            return dtos;
        }

        [HttpPost]
        [Route("/basket/add")]
        public async Task<ActionResult> BasketAdd(int userId, int productId, int quantity)
        {
            Database.Context.Baskets.Add(new Basket() { IdCustomer = userId, IdProduct=productId, Quantity=quantity });
            Database.Context.SaveChanges();

            return Ok();
        }
    }
}
