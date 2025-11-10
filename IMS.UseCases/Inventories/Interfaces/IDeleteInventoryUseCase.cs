using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}