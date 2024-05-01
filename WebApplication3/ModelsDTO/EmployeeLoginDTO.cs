using WebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.ModelsDTO
{
    public class EmployeeLoginDTO
    {
        public string login { get; set; }

        public string password { get; set; }
        //public string firstName { get; set; }
        //public string lastName { get; set; }
        //public string patronymic { get; set; }

        public EmployeeLoginDTO(string login, string password)
        {
            this.login = login;
            this.password = password;
            //this.firstName = firstName;
            //this.lastName = lastName;
            //this.patronymic = patronymic;
        }

    }



}
