using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class ConsignmentsController : Controller
    {
    
        [Route("/consignement")]
        [HttpGet]
        public ActionResult<List<ConsignmentDTO>> list1()
        {

            var result = new List<ConsignmentDTO>();
            var consignments = Database.Context.Consignments.ToList();

            foreach (var consignment in consignments)
            {
                result.Add(ConsignmentDTO.ConsigConverter(consignment));
            }

            return Ok(result);
        }
        [Route("/consignement/{id_sklad}")]
        [HttpGet]
        public ActionResult<List<ConsignmentDTO>> list2(int id_sklad)
        {

            var result = new List<ConsignmentDTO>();
            var sklads = Database.Context.Consignments.ToList().Where(x => x.Warehouse==id_sklad);


            if (sklads != null)
            {
                foreach (var sklad in sklads)
                {
                    result.Add(ConsignmentDTO.ConsigConverter(sklad));
                }

                return Ok(result);
            }
            else { return NotFound("no"); }
        }


        [HttpGet]
        [Route("/consignements/{id}")]
        public ActionResult<Consignment> el(int id)
        {
            Consignment? consignment = Database.Context.Consignments.ToList().FirstOrDefault(x => x.IdConsignment == id);
            if (consignment != null)
            {
                return consignment;
            }
            else
                return NotFound();
        }

        
        [HttpPost]
        [Route("/consignements")]
        public ActionResult<Consignment> reg([FromBody] Consignment consignment)
        {
            if (consignment == null)
                return BadRequest();

            if (Database.Context.Consignments.FirstOrDefault(x => x.IdConsignment == consignment.IdConsignment) != null)
                return Problem();

            Database.Context.Consignments.Add(consignment);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("/consignements")]
        public ActionResult<Consignment> put([FromBody] Consignment consignment)
        {
            if (consignment == null)
                return BadRequest();

            if (Database.Context.Consignments.FirstOrDefault(x => x.IdConsignment == consignment.IdConsignment) == null)
                return NotFound();

            Database.Context.Consignments.Add(consignment);
            Database.Context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("/consignments/{id}")]
        public ActionResult<Consignment> del(int id)
        {
            Consignment? consignment = Database.Context.Consignments.ToList().FirstOrDefault(x => x.IdConsignment == id);
            if (consignment != null)
            {
                Database.Context.Consignments.Remove(consignment);
                return Ok();
            }
            else
                return NotFound();
        }
  
    }
}
