using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}
