using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync(int id);
        Task<List<Address>> GetAddressesAsync(AddressQueryParameters query);
        Task<Address> AddAddressAsync(Address address);
        Task<bool> UpdateAddressAsync(Address address);
        Task<bool> DeleteAddressAsync(int id);
    }
}
