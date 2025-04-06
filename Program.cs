using EShop.Application;
using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("TestDb"));
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using (var scope = app.Services.CreateScope())
{
    var seeder = new EShop.Domain.Seeders.EShopSeeder();
    EShop.Domain.Seeders.EShopSeeder.Seed(scope.ServiceProvider);
}
