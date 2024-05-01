using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Services
{
    public class WarehouseService
    {
        public List<Warehouse> GetAllWarehouses()
        {
            return Database.Context.Warehouses.ToList();
        }
    }
}
