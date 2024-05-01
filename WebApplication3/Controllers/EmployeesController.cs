using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;
using WebApplication3.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    public class EmployeesController : Controller
    {
        [Route("/employees/auth")]
        [HttpPost]
        public ActionResult<EmployeesResponseDTO> auth([FromBody] EmployeeLoginDTO employeeLoginDTO)
        {
            if (employeeLoginDTO == null)
                return BadRequest();

            Employee employeeFromDB = Database.Context.Employees.FirstOrDefault(x => x.Login == employeeLoginDTO.login && x.Password == employeeLoginDTO.password);

            if (employeeFromDB == null)
                return NotFound("Неверный логин или пароль");

            return EmployeesResponseDTO.EmployeeResponseConverter(employeeFromDB);
        }

        [Route("/employees")]
        [HttpGet]
        public ActionResult<List<EmployeesResponseDTO>> list1()
        {
            var result = new List<EmployeesResponseDTO>();
            var employees = Database.Context.Employees.ToList();

            foreach (var e in employees)
            {
                result.Add(EmployeesResponseDTO.EmployeeResponseConverter(e));
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("/employees/{login}")]
        public ActionResult<EmployeesResponseDTO> el(string login)
        {
            Employee? employee = Database.Context.Employees.ToList().FirstOrDefault(x => x.Login == login);
            if (employee != null)
            {
                return EmployeesResponseDTO.EmployeeResponseConverter(employee);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("/employees")]
        public ActionResult<Employee> vi([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (Database.Context.Employees.FirstOrDefault(x => x.IdEmployee == employee.IdEmployee) != null)
                return Problem();

            Database.Context.Employees.Add(employee);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("/employees/{gender}/{password}/{login}")]
        public ActionResult<Employee> pu(string gender, string password, string login)
        {
            //if (employee == null)
            //    return BadRequest();

            //if (Database.Context.Employees.FirstOrDefault(x => x.IdEmployee == employee.IdEmployee) == null)
            //    return NotFound();

            //Database.Context.Employees.Add(employee); 
            //Database.Context.SaveChanges();

            //return Ok();
          

           Employee  employee = Database.Context.Employees.FirstOrDefault(x => x.Login == login);
            employee.Gender = gender;
            employee.Password = password;
                

            //Database.Context.Employees.Add(employee);
            Database.Context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("/employees/{id}")]
        public ActionResult<Employee> del(int id)
        {
            Employee? employee = Database.Context.Employees.ToList().FirstOrDefault(x => x.IdEmployee == id);
            if (employee != null)
            {
                Database.Context.Employees.Remove(employee);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
