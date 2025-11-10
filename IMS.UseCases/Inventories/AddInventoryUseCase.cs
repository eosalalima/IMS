using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public AddInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            // Add any business logic or validation here if needed
            await this.inventoryRepository.AddInventoryAsync(inventory);
        }
    }
}