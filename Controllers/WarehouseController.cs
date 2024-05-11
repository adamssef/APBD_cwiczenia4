using System;
using AnimalsAppHorizontal.Model;
using AnimalsAppHorizontal.Repositories;
using AnimalsAppHorizontal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAppHorizontal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    /// <summary>
    /// Endpoint to add a product to the warehouse if all conditions are met.
    /// </summary>
    /// <param name="data">Data including IdProduct, IdWarehouse, Amount, and CreatedAt</param>
    /// <returns>The primary key of the record inserted into the Product_Warehouse table</returns>
    [HttpPost("AddProductToWarehouse")]
    public IActionResult AddProductToWarehouse([FromBody] ProductWarehouse data)
    {
        if (data == null || data.Amount <= 0)
        {
            return BadRequest("Invalid data provided.");
        }

        bool productExists = _warehouseService.DoesProductExist(data.IdProduct.ToString());
        if (!productExists)
        {
            return NotFound($"Product with ID {data.IdProduct} not found.");
        }

        bool warehouseExists = _warehouseService.DoesWarehouseExist(data.IdWarehouse.ToString());
        if (!warehouseExists)
        {
            return NotFound($"Warehouse with ID {data.IdWarehouse} not found.");
        }

        bool orderExists = _warehouseService.DoesOrderExist(data.IdProduct, data.Amount);
        if (!orderExists)
        {
            return BadRequest("No corresponding order found or order amount mismatch.");
        }

        bool orderDateValid = _warehouseService.IsOrderDateEarlierThanDateFromRequest(data.CreatedAt);
        if (!orderDateValid)
        {
            return BadRequest("Order date must be earlier than the provided creation date.");
        }

        bool isFulfilled = _warehouseService.IsOrderFulfilled(_warehouseService.GetOrderIdByProductAndAmount(data.IdProduct, data.Amount));
        if (isFulfilled)
        {
            return BadRequest("Order is already fulfilled.");
        }

        _warehouseService.UpdateFulfilledAt(data.IdOrder);
        int productPrice = _warehouseService.GetProductPrice(data.IdProduct);
        _warehouseService.CreateProductWarehouseRecord(data.IdWarehouse, data.IdProduct, data.Amount, productPrice, data.CreatedAt);

        return Ok("Record added successfully, [PrimaryKeyValue]"); // Replace [PrimaryKeyValue] with actual primary key if needed
    }
}
