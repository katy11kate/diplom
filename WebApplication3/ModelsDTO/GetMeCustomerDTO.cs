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
                orders.Add(
                    new MyOrdersListDTO() 
                    { 
                        DateDelivery = order.DateDelivery, 
                        DateOrder = order.DateOrder, 
                        Price = order.TotalPrice ?? 0,
                        ProductsInfo = GetMyProductDetailsInfo(order)
                    }
                );
            }

            return orders;
        }

        private static List<ProductDetailsInfo> GetMyProductDetailsInfo(Order order)
        {
            var products = new List<ProductDetailsInfo>();

            foreach (var orderlist in order.Orderlists)
            {
                products.Add(new ProductDetailsInfo()
                {
                    Product = ProductDTO.ProductResponseConverter(orderlist.IdProductNavigation),
                    Amount = orderlist.Count ?? 0,
                });
            }

            return products;
        }
    }
}
