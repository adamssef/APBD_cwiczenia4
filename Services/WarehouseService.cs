using System;
using AnimalsAppHorizontal.Model;
using AnimalsAppHorizontal.Repositories;

namespace AnimalsAppHorizontal.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public bool DoesProductExist(string idProduct)
    {
        return _warehouseRepository.DoesProductExist(idProduct);
    }

    public bool DoesWarehouseExist(string idWarehouse)
    {
        return _warehouseRepository.DoesWarehouseExist(idWarehouse);
    }

    public bool DoesOrderExist(int idProduct, int amount)
    {
        return _warehouseRepository.DoesOrderExist(idProduct, amount);
    }

    public bool IsOrderDateEarlierThanDateFromRequest(DateTime dateFromRequest)
    {
        return _warehouseRepository.IsOrderDateEarlierThanDateFromRequest(dateFromRequest);
    }

    public bool IsOrderFulfilled(int idOrder)
    {
        return _warehouseRepository.IsOrderFulfilled(idOrder);
    }

    public void UpdateFulfilledAt(int idOrder)
    {
        _warehouseRepository.UpdateFulfilledAt(idOrder);
    }

    public void CreateProductWarehouseRecord(int idWarehouse, int idProduct, int amount, int price, DateTime createdAt)
    {
        _warehouseRepository.CreateProductWarehouseRecord(idWarehouse, idProduct, amount, price, createdAt);
    }

    public int GetProductPrice(int idProduct) {
        return _warehouseRepository.GetProductPrice(idProduct);
    }

    public int GetOrderIdByProductAndAmount(int idProduct, int Amount) {
        return _warehouseRepository.GetOrderIdByProductAndAmount(idProduct, Amount);
    }
}
