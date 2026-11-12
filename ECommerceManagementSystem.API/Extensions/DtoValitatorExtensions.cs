using ECommerceManagementSystem.Application.Validators;
using FluentValidation;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class DtoValitatorExtensions
    {
        public static IServiceCollection AddDtoValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AddAddressRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAddressRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<AddCategoryRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<AddProductRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateProductRequestDtoValidator>();

            return services;
        }
    }
}
