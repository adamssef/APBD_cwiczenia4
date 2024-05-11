using System.Data.SqlClient;
using AnimalsAppHorizontal.Model;

namespace AnimalsAppHorizontal.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private IConfiguration _configuration;
    
    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

   public bool DoesProductExist(string idProduct)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand($"SELECT COUNT(1) FROM Master.dbo.Product WHERE IdProduct = @IdProduct", connection);
        cmd.Parameters.AddWithValue("@IdProduct", idProduct);
        return (int)cmd.ExecuteScalar() > 0;
    }

    public bool DoesWarehouseExist(string idWarehouse)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand($"SELECT COUNT(1) FROM Master.dbo.Warehouse WHERE IdWarehouse = @IdWarehouse", connection);
        cmd.Parameters.AddWithValue("@IdWarehouse", idWarehouse);
        return (int)cmd.ExecuteScalar() > 0;
    }

public bool DoesOrderExist(int idProduct, int amount)
{
    using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
    connection.Open();
    var cmd = new SqlCommand(@"
    SELECT COUNT(*) 
    FROM [Order]
    WHERE IdProduct = @IdProduct 
      AND Amount = @Amount", connection);

    cmd.Parameters.AddWithValue("@IdProduct", idProduct);
    cmd.Parameters.AddWithValue("@Amount", amount);

    int test = (int)cmd.ExecuteScalar();
    Console.WriteLine(test);

    return (int)cmd.ExecuteScalar() > 0;
}

    public bool IsOrderDateEarlierThanDateFromRequest(DateTime dateFromRequest)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand($"SELECT COUNT(1) FROM [Order] WHERE CreatedAt < @DateFromRequest", connection);
        cmd.Parameters.AddWithValue("@DateFromRequest", dateFromRequest);
        return (int)cmd.ExecuteScalar() > 0;
    }

    public bool IsOrderFulfilled(int idOrder)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand($"SELECT COUNT(1) FROM [Order] WHERE IdOrder = @IdOrder AND FulfilledAt IS NOT NULL", connection);
        cmd.Parameters.AddWithValue("@IdOrder", idOrder);
        return (int)cmd.ExecuteScalar() > 0;
    }

    public void UpdateFulfilledAt(int idOrder)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand($"UPDATE [Order] SET FulfilledAt = GETDATE() WHERE IdOrder = @IdOrder", connection);
        cmd.Parameters.AddWithValue("@IdOrder", idOrder);
        cmd.ExecuteNonQuery();
    }

    public int CreateProductWarehouseRecord(int idWarehouse, int idProduct, int amount, int price, DateTime createdAt)
    {
        price = GetProductPrice(idProduct) * amount;
        int idOrder = GetOrderIdByProductAndAmount(idProduct, amount);

        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var cmd = new SqlCommand("INSERT INTO [Product_Warehouse] (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) OUTPUT INSERTED.IdProductWarehouse VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)", connection);
        cmd.Parameters.AddWithValue("@IdWarehouse", idWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", idProduct);
        cmd.Parameters.AddWithValue("@Amount", amount);
        cmd.Parameters.AddWithValue("@IdOrder", idOrder);
        cmd.Parameters.AddWithValue("@Price", price);
        cmd.Parameters.AddWithValue("@CreatedAt", createdAt);
        
        var insertedId = (int)cmd.ExecuteScalar();
        return insertedId;
    }

   public int GetProductPrice(int idProduct)
   {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        {
            connection.Open();
            var query = "SELECT Price FROM Product WHERE IdProduct = @IdProduct";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdProduct", idProduct);
                
                var result = command.ExecuteScalar();
                if(result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Product not found or price is null");
                }
            }
        }
    }

    public int GetOrderIdByProductAndAmount(int idProduct, int amount)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        {
            connection.Open();
            var cmd = new SqlCommand(@"
                SELECT TOP 1 IdOrder
                FROM [Order]
                WHERE IdProduct = @IdProduct AND Amount = @Amount
                ORDER BY IdOrder DESC", connection);

            cmd.Parameters.AddWithValue("@IdProduct", idProduct);
            cmd.Parameters.AddWithValue("@Amount", amount);

            var result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                throw new Exception("No order found matching the criteria.");
            }
        }
    }
    
}
