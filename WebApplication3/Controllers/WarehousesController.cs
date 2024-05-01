using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class WarehousesController : Controller
    {
        [Route("/warehouses")]
        [HttpGet]
        public ActionResult<List<Warehouse>> list1()
        {
            return Database.Context.Warehouses.ToList();
        }

        [Route("/warehouses/:id")]
        [HttpGet]
        public ActionResult<Warehouse> GetWarehouseById([FromQuery] int id)
        {
            var w = Database.Context.Warehouses.FirstOrDefault(p => p.IdWarehouse == id);

            if (w == null)
            {
                return BadRequest("Провайдера с таким id не найдено");
            }

            //var dto = new WarehousesDTO
            //{
            //    Adress = warehouse.Adress,
            //    WarehouseName = warehouse.WarehouseName,
            //    IdWarehouse = warehouse.IdWarehouse,
            //    Consignments = warehouse.Consignments,
            //    Orders = warehouse.Orders,
            //    ProductAvailabilities = warehouse.ProductAvailabilities
            //};

            return Ok(new 
                { 
                    w.IdWarehouse, w.Adress, w.WarehouseName, Orders = w.Orders.Select(o => o.IdOrder), Consignments = w.Consignments.Select(c => c.IdProvider)
                }
           );
        }
    }
}
