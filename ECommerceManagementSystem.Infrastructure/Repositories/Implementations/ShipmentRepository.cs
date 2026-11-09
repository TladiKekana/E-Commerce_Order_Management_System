using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly DataContext _context;

        public ShipmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Shipment> AddShipmentAsync(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return shipment;
        }

        public async Task<bool> DeleteShipmentAsync(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);

            if(shipment == null)
                return false;

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Shipment> GetShipmentAsync(int id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task<List<Shipment>> GetShipmentsAsync()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task<bool> UpdateShipmentAsync(Shipment shipment)
        {
            var currentShipment = await _context.Shipments.FindAsync(shipment.Shipment_Id);

            if (currentShipment == null)
                return false;

            _context.Shipments.Entry(currentShipment).CurrentValues.SetValues(shipment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
