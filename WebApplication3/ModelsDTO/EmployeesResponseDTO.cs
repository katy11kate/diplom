using WebApplication3.Models;

namespace WebApplication3.ModelsDTO
{
    public class EmployeesResponseDTO
    {

        public string login { get; set; }

        public string password { get; set; }
        public string firstName { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public List<int> consignments { get; set; }
        public string gender { get; set; }
        public string telephone { get; set; }
        public string post { get; set; }


        //public EmployeesResponseDTO(string login, string password, string firstName, string lastName, string patronymic)
        //{
        //    this.login = login;
        //    this.password = password;
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.patronymic = patronymic;
        //}
        public static EmployeesResponseDTO EmployeeResponseConverter(Employee employee)
        {
            EmployeesResponseDTO employeesResponseDTO = new EmployeesResponseDTO();
            employeesResponseDTO.password = employee.Password;
            employeesResponseDTO.firstName = employee.Firstname;
            employeesResponseDTO.name = employee.Name;
            employeesResponseDTO.patronymic = employee.Patronymic;
            employeesResponseDTO.login= employee.Login;
            employeesResponseDTO.consignments = employee.Consignments.Select(c => c.IdConsignment).ToList();
            employeesResponseDTO.gender = employee.Gender;
            employeesResponseDTO.telephone = employee.Telephone;
            employeesResponseDTO.post = employee.Post;

            return employeesResponseDTO;
        }
    }
}
