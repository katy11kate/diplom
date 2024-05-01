using WebApplication3.Models;

namespace WebApplication3.ModelsDTO
{
    public class ConsignmentDTO
    {
        public int idConsignment { get; set; }

        public string nameProvider { get; set; }

        public DateTime? deliveryDate { get; set; }

        public string responsibleEmployee { get; set; }

        public string warehouse { get; set; }


        public static ConsignmentDTO ConsigConverter(Consignment consignment)
        {
            ConsignmentDTO consignmentDTO = new ConsignmentDTO();
            consignmentDTO.idConsignment = consignment.IdConsignment;
            consignmentDTO.deliveryDate = consignment.DeliveryDate;
            consignmentDTO.nameProvider = consignment.IdProviderNavigation.NameOrganization;
            consignmentDTO.responsibleEmployee = consignment.ResponsibleEmployeeNavigation.Login;
            consignmentDTO.warehouse = consignment.WarehouseNavigation.WarehouseName;
            return consignmentDTO;
        }
    }
}
