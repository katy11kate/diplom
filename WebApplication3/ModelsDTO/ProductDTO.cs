using WebApplication3.Models;

namespace WebApplication3.ModelsDTO
{
    public class ProductDTO
    {
        public string Barcode { get; set; }
        public string NameProduct { get; set; }
        public int IdProduct { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public List<string> Images { get; set; }
            
        public static ProductDTO ProductResponseConverter(Product product)
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.Barcode = product.Barcode;
            productDTO.NameProduct = product.NameProduct;
            productDTO.IdProduct = product.IdProduct;
            productDTO.Color = product.Color;
            productDTO.Size = product.Size; ;
            productDTO.Description = product.Description;
            productDTO.Images = product.Images.Select(im => im.RouteImage).ToList();
            productDTO.Cost = product.Cost;

            return productDTO;
        }

    }
}
