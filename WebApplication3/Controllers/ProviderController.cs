using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("/provider")]
    public class ProviderController : Controller
    {
        [HttpGet]
        [Route("/:id")]
        public ActionResult<Provider> GetProviderById([FromQuery] int id)
        {
            
            var provider = Database.Context.Providers.FirstOrDefault(p => p.IdProvider == id);

            if (provider == null)
            {
                return BadRequest("Провайдера с таким id не найдено");
            }

            return Ok(provider);
        }
       
    }
}
