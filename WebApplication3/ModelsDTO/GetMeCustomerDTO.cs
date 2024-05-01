using WebApplication3.Models;

namespace WebApplication3.ModelsDTO
{
    public class GetMeCustomerDTO
    {
        public int IdCustomer { get; set; }

        public string? Firstname { get; set; }

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Telephone { get; set; } = null!;

        public DateOnly? Birthdate { get; set; }

        public string Login { get; set; } = null!;
        public List<MyOrdersListDTO> orders { get; set; } = null!;

        public static GetMeCustomerDTO ConvertToGetMeCustomerDto(Customer me)
        {
            return new GetMeCustomerDTO
            {
                IdCustomer = me.IdCustomer,
                Birthdate = me.Birthdate,
                Login = me.Login,
                Telephone = me.Telephone,
                Patronymic = me.Patronymic,
                Name = me.Name,
                Firstname = me.Firstname,
                orders = GetMyOrders(me)
            };
        }

        private static List<MyOrdersListDTO> GetMyOrders(Customer me)
        {
            var orders = new List<MyOrdersListDTO>();

            foreach (var order in me.Orders)
            {
                order.Orderlists.
            }
        }
    }
}
