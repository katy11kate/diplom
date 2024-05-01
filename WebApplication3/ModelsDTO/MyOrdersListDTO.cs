namespace WebApplication3.ModelsDTO
{
    public class MyOrdersListDTO
    {
        public List<ProductDetailsInfo> ProductsInfo { get; set; }
        public decimal Price { get; set; }
        public DateOnly DateOrder { get; set; }
        public DateOnly DateDelivery { get; set; }
    }

    public class ProductDetailsInfo
    {
        public ProductDTO Product { get; set; }
        public int Amount { get; set; }
    }
}
