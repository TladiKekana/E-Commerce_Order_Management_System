using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Helpers;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<Address> AddAddressAsync(Address address)
        {
            return await _repository.AddAddressAsync(address);
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            return await _repository.DeleteAddressAsync(id);
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            return await _repository.GetAddressAsync(id);
        }

        public async Task<List<Address>> GetAddressesAsync(AddressQueryParameters query)
        {
            return await _repository.GetAddressesAsync(query);
        }

        public async Task<bool> UpdateAddressAsync(Address address)
        {
            return await _repository.UpdateAddressAsync(address);
        }
    }
}
