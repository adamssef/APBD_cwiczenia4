using System;
using AnimalsAppHorizontal.Model;

namespace AnimalsAppHorizontal.Services;

public interface IWarehouseService
{
    bool DoesProductExist(string idProduct);
    bool DoesWarehouseExist(string idWarehouse);
    bool DoesOrderExist(int idProduct, int amount);
    bool IsOrderDateEarlierThanDateFromRequest(DateTime dateFromRequest);
    bool IsOrderFulfilled(int idOrder);
    void UpdateFulfilledAt(int idOrder);
    void CreateProductWarehouseRecord(int idWarehouse, int idProduct, int amount, int price, DateTime createdAt);
    int GetProductPrice(int idProduct);
}
