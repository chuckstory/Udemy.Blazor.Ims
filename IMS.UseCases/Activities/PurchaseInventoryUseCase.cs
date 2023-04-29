using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Activities.Interfaces;

namespace IMS.UseCases.Activities
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IInventoryRepository inventoryRepository;

        public PurchaseInventoryUseCase(IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
            this.inventoryTransactionRepository = inventoryTransactionRepository;

        }

        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            inventoryTransactionRepository.PurchaseAsync(poNumber, inventory, quantity, doneBy, inventory.Price);

            inventory.Quantity += quantity;
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}