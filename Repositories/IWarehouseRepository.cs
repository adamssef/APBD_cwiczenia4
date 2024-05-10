using AnimalsAppHorizontal.Model;

namespace AnimalsAppHorizontal.Repositories;

public interface IWarehouseRepository
{
    bool DoesProductExist(string idProduct);
    bool DoesWarehouseExist(string idWarehouse);
    bool DoesOrderExist(int idProduct, int amount);
    bool IsOrderDateEarlierThanDateFromRequest(DateTime dateFromRequest);
    bool IsOrderFulfilled(int idOrder);
    void UpdateFulfilledAt(int idOrder);
    int CreateProductWarehouseRecord(int idWarehouse, int idProduct, int amount, int price, DateTime createdAt);
    int GetProductPrice(int idProduct);
    int GetOrderIdByProductAndAmount(int idProduct, int amount);
}