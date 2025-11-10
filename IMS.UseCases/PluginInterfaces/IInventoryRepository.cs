namespace IMS.UseCases.PluginInterfaces
{
    using IMS.CoreBusiness;
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);

        Task UpdateInventoryAsync(Inventory inventory);

        Task<Inventory> GetInventoryByIdAsync(int inventoryId);

        Task DeleteInventoryByIdAsync(int inventoryId);
    }
}