using Microsoft.EntityFrameworkCore;
using Shopping.BLL.Contract.Contract;
using Shopping.BLL.Services;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.DbContexts;
using Shopping.DAL.Repositories;
using Shopping.DAL.UnitOfWorks;

namespace Market.Infrastructure;

public static class ServiceConfiguration
{
    public static void RegistrationService(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<EFDbContext>(d => d.UseSqlServer("Password=1;Persist Security Info=True;User ID=sa;Initial Catalog=PDB;Data Source=.;TrustServerCertificate=Yes"));

        builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductBLL, ProductBLL>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICartBLL, CartBLL>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IOrderBLL, OrderBLL>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    }
}