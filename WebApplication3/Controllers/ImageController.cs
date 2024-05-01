using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class ImageController : Controller
    {
        [Route("/images")]
        [HttpGet]
        public ActionResult<List<Image>> list1()
        {
            return Database.Context.Images.ToList();
        }



        [HttpGet]
        [Route("/images/{id}")]
        public ActionResult<Image> el(int id)
        {
            WebApplication3.Models.Image? image = Database.Context.Images.ToList().FirstOrDefault(x => x.IdImage == id);
            if (image != null)
            {
                return image;
            }
            else
                return NotFound();
        }


        [HttpPost]
        [Route("/images")]
        public ActionResult<Image> vi([FromBody] Image image)
        {
            if (image == null)
                return BadRequest();

            if (Database.Context.Images.FirstOrDefault(x => x.IdImage == image.IdImage) != null)
                return Problem();

            Database.Context.Images.Add(image);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("/images")]
        public ActionResult<Image> put([FromBody] WebApplication3.Models.Image image)
        {
            if (image == null)
                return BadRequest();

            if (Database.Context.Images.FirstOrDefault(x => x.IdImage == image.IdImage) == null)
                return NotFound();

            Database.Context.Images.Add(image);
            Database.Context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Route("/images/{id}")]
        public ActionResult<Image> del(int id)
        {
            Image? image = Database.Context.Images.ToList().FirstOrDefault(x => x.IdImage == id);
            if (image != null)
            {
                Database.Context.Images.Remove(image);
                return Ok();
            }
            else
                return NotFound();
        }



    }
}
