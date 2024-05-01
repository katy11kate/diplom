using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Services
{
    public class CustomerService
    {
        public Customer GetCustomerById(int id)
        {
            var candidate = Database.Context.Customers.Where(c => c.IdCustomer== id).FirstOrDefault();

            if (candidate == null)
            {
                throw new Exception("Клиента с таким уникальным кодом не найдено");
            }

            return candidate;
        }
    }
}
