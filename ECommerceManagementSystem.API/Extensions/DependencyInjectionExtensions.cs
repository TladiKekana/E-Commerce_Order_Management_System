using ECommerceManagementSystem.Infrastructure.Repositories.Implementations;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Implementations;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            // Register Business Logic Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();

            return services;
        }
    }
}
