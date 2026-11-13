using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Infrastructure.Helpers;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Address> AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            
            return address;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
                return false;

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<List<Address>> GetAddressesAsync(AddressQueryParameters query)
        {
            var addresses = _context.Addresses.AsQueryable();

            // Filtering
            if(!string.IsNullOrEmpty(query.Province))
                addresses = addresses.Where(a =>  a.Province == query.Province);

            if(!string.IsNullOrEmpty(query.Country))
                addresses = addresses.Where(a => a.Country == query.Country);

            if (!string.IsNullOrEmpty(query.City))
                addresses = addresses.Where(a => a.City == query.City);

            // Sorting
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                switch(query.SortBy.ToLower())
                {
                    case "province": addresses = addresses.OrderBy(a => a.Province); break;
                    case "country": addresses = addresses.OrderBy(a => a.Province); break;
                    case "city": addresses = addresses.OrderBy(a => a.Province); break;
                    default : addresses = addresses.OrderBy(a => a.Address_Id); break;
                }
            }

            // Pagination
            addresses = addresses
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await addresses.ToListAsync();
        }

        public async Task<bool> UpdateAddressAsync(Address address)
        {
            var currentAddress = await _context.Addresses.FindAsync(address.Address_Id);

            if (currentAddress == null)
                return false;

            _context.Addresses.Entry(currentAddress).CurrentValues.SetValues(address);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
