using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class ProductAvailabilitiesController : Controller
    {
        [Route("/productAvailabilities")]
        [HttpGet]
        public ActionResult<List<ProductAvailability>> list1()
        {
            return Database.Context.ProductAvailabilities.ToList();
        }


        [HttpGet]
        [Route("/productAvailabilities/{id}")]
        public ActionResult<ProductAvailability> el(int id)
        {
            ProductAvailability? productAvailabilitie = Database.Context.ProductAvailabilities.ToList().FirstOrDefault(x => x.IdProduct == id);
            if (productAvailabilitie != null)
            {
                return productAvailabilitie;
            }
            else
                return NotFound();
        }



    }
}
