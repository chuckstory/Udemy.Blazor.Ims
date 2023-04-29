using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public List<InventoryTransaction> _inventoryTransactions = new List<InventoryTransaction>();

        public Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            throw new NotImplementedException();
        }

        public Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price)
        {
            throw new NotImplementedException();
        }

        public Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QauntityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QauntityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            return Task.CompletedTask;
        }
    }
}