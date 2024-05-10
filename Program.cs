using AnimalsAppHorizontal.Repositories;
using AnimalsAppHorizontal.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Registering services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        // Register repository and service for Animals
        builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
        builder.Services.AddScoped<IAnimalsService, AnimalsService>();

        // Register repository and service for Warehouse
        builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();  // Assuming you have a WarehouseRepository
        builder.Services.AddScoped<IWarehouseService, WarehouseService>();

        var app = builder.Build();

        // Configuring the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
