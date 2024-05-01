using Castle.Core.Resource;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class WeatherForecastController : ControllerBase
    {
        [Route("/customers/auth")]
        [HttpPost]
        public ActionResult<Customer> auth([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            Customer? customerFromDB = Database.Context.Customers.FirstOrDefault(x => x.Login == customer.Login && x.Password == customer.Password);

            if (customerFromDB == null)
                return NotFound("Неверный логин или пароль");

            return customerFromDB;
        }
        [HttpPost]
        [Route("/customers/reg")]
        public ActionResult<Customer> reg([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            if (Database.Context.Customers.FirstOrDefault(x => x.IdCustomer == customer.IdCustomer) != null)
                return Problem();

            Database.Context.Customers.Add(customer);
            Database.Context.SaveChanges();

            return Ok();
        }

        [Route("/customers")]
        [HttpGet]
        public ActionResult<List<Customer>> list1()
        {
           return Database.Context.Customers.ToList();
        }

        [HttpGet]
        [Route("/customers/{id}")]
        public ActionResult<Customer> el(int id)
        {
            Customer? customer = Database.Context.Customers.ToList().FirstOrDefault(x => x.IdCustomer == id);
            if (customer != null)
            {
                return customer;
            }
            else
                return NotFound();
        }

        [HttpPut]
        [Route("/customers")]
        public ActionResult<Customer> put([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (Database.Context.Customers.FirstOrDefault(x => x.IdCustomer == customer.IdCustomer) == null)
                return NotFound();

            Database.Context.Customers.Add(customer);
            Database.Context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Route("/customers/{id}")]
        public ActionResult<Customer> del(int id)
        {
            Customer? customer = Database.Context.Customers.ToList().FirstOrDefault(x => x.IdCustomer == id);
            if (customer != null)
            {
                Database.Context.Customers.Remove(customer);
                return Ok();
            }
            else
                return NotFound();
        }


    }
}