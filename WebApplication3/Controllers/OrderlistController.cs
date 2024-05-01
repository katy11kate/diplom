using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class OrderlistController : Controller
    {
        [Route("/orderlists")]
        [HttpGet]
        public ActionResult<List<Orderlist>> list1()
        {
            return Database.Context.Orderlists.ToList();
        }

        [HttpGet]
        [Route("/orderlists/{id}")]
        public ActionResult<Orderlist> el(int id)
        {
            Orderlist? orderList = Database.Context.Orderlists.ToList().FirstOrDefault(x => x.Idorderlist == id);
            if (orderList != null)
            {
                return orderList;
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("/orderlists")]
        public ActionResult<Orderlist> post([FromBody] Orderlist orderlist)
        {
            if (orderlist == null)
                return BadRequest();

            if (Database.Context.Orderlists.FirstOrDefault(x => x.Idorderlist == orderlist.Idorderlist) != null)
                return Problem();

            Database.Context.Orderlists.Add(orderlist);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("/orderlists/gg")]
        public ActionResult<Orderlist> Dobavlinie([FromBody] Orderlist orderList)
        {
            if (orderList == null)
                return BadRequest();

            if (Database.Context.Orderlists.FirstOrDefault(x => x.Idorderlist == orderList.Idorderlist) != null)
                return Problem();

            Database.Context.Orderlists.Add(orderList);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("/orderlists")]
        public ActionResult<Orderlist>Izmenenie([FromBody] Orderlist orderList)
        {
            if (orderList == null)
                return BadRequest();

            if (Database.Context.Orderlists.FirstOrDefault(x => x.Idorderlist == orderList.Idorderlist) == null)
                return NotFound();

            Database.Context.Orderlists.Add(orderList);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("/orderlists")]
        public ActionResult<Orderlist>Udalenie(int id)
        {
            Orderlist? orderList = Database.Context.Orderlists.ToList().FirstOrDefault(x => x.Idorderlist == id);
            if (orderList != null)
            {
                Database.Context.Orderlists.Remove(orderList);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
