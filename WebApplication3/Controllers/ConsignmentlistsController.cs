using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class ConsignmentlistsController : Controller
    {


        [Route("/consignmentlist/{idconsignment}")]
        [HttpGet]
        public ActionResult<List<ConsignmentListDTO>> list2(int idconsignment)
        {

            var result = new List<ConsignmentListDTO>();
            var consignmentlists = Database.Context.Consignmentlists.ToList().Where(x => x.IdConsignmen==idconsignment);


            if (consignmentlists != null)
            {
                foreach (var consignmentlist in consignmentlists)
                {
                    result.Add(ConsignmentListDTO.ConsigListConverter(consignmentlist));
                }

                return Ok(result);
            }
            else { return NotFound("no"); }
        }
        [Route("/consignementlist")]
        [HttpGet]
        public ActionResult<List<Consignmentlist>> list1()
        {
            return Database.Context.Consignmentlists.ToList();
        }

        [HttpGet]
        [Route("/consignementlist/{id}")]
        public ActionResult<Consignmentlist> el(int id)
        {
            Consignmentlist? consignmentList = Database.Context.Consignmentlists.ToList().FirstOrDefault(x => x.IdConsignmen == id);
            if (consignmentList != null)
            {
                return consignmentList;
            }
            else
                return NotFound();
        }


        [HttpPost]
        [Route("/consignementlist")]
        public ActionResult<Consignmentlist> reg([FromBody] Consignmentlist consignmentlist)
        {
            if (consignmentlist == null)
                return BadRequest();

            if (Database.Context.Consignmentlists.FirstOrDefault(x => x.IdConsignmen == consignmentlist.IdConsignmen) != null)
                return Problem();

            Database.Context.Consignmentlists.Add(consignmentlist);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("/consignementlist")]
        public ActionResult<Consignmentlist> put([FromBody] Consignmentlist consignmentlist)
        {
            if (consignmentlist == null)
                return BadRequest();

            if (Database.Context.Consignmentlists.FirstOrDefault(x => x.IdConsignmen == consignmentlist.IdConsignmen) == null)
                return NotFound();

            Database.Context.Consignmentlists.Add(consignmentlist);
            Database.Context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("/consignmentlists/{id}")]
        public ActionResult<Consignmentlist> del(int id)
        {
            Consignmentlist? consignmentLists = Database.Context.Consignmentlists.ToList().FirstOrDefault(x => x.IdConsignmen == id);
            if (consignmentLists != null)
            {
                Database.Context.Consignmentlists.Remove(consignmentLists);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
