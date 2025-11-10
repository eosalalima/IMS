using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>()
        {
            new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2.00 },
            new Inventory { InventoryId = 2, InventoryName = "Bike Frame", Quantity = 10, Price = 15.00 },
            new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8.00 },
            new Inventory { InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 5.00 },
            new Inventory { InventoryId = 5, InventoryName = "Bike Chain", Quantity = 25, Price = 7.00 },
        };
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var maxId = _inventories.Max(x => x.InventoryId);
        inventory.InventoryId = maxId + 1;

        _inventories.Add(inventory);

       return Task.CompletedTask;
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return await Task.FromResult(_inventories);

        return await Task.FromResult(_inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)));
    }

    public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
    {
        var inventory = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
        return await Task.FromResult(inventory);
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase) && x.InventoryId != inventory.InventoryId))
            return Task.CompletedTask;

        var existingInventory = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
        if (existingInventory != null)
        {
            existingInventory.InventoryName = inventory.InventoryName;
            existingInventory.Quantity = inventory.Quantity;
            existingInventory.Price = inventory.Price;
        }

        return Task.CompletedTask;
    }
}
