using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
app.MapControllers();
try
{
    using var scope =app.Services.CreateAsyncScope();
    var Services  = scope.ServiceProvider;
    var context =  Services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
    throw;
}
app.Run();