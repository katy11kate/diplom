using WebApplication3.Models;

namespace WebApplication3.ModelsDTO
{
    public class ConsignmentListDTO
    {
      
            public int? idConsignment { get; set; }

            public string nameProduct { get; set; }

            public string size { get; set; }

            public int? count { get; set; }

            public decimal? price { get; set; }
        public string color { get; set; }


        public static ConsignmentListDTO ConsigListConverter(Consignmentlist consignmentlist)
        {
            ConsignmentListDTO consignmenlisttDTO = new ConsignmentListDTO();
            consignmenlisttDTO.idConsignment = consignmentlist.IdConsignmen;
            consignmenlisttDTO.nameProduct = consignmentlist.IdProductNavigation.NameProduct;
            consignmenlisttDTO.size = consignmentlist.IdProductNavigation.Size;
            consignmenlisttDTO.count = consignmentlist.Count;
            consignmenlisttDTO.price = consignmentlist.IdProductNavigation.Cost; ;
            consignmenlisttDTO.color = consignmentlist.IdProductNavigation.Color; ;

            return consignmenlisttDTO;
        }
    }
}
