using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System.Runtime.CompilerServices;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;


        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat 1", Quantity = 120, Price = 22 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat 2", Quantity = 130, Price = 23 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat 3", Quantity = 140, Price = 24 },
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return await Task.FromResult(_inventories.Where(i => i.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)));
        }
    }
}