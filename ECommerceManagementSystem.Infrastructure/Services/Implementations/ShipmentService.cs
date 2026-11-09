using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _repository;

        public ShipmentService(IShipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Shipment> AddShipmentAsync(Shipment shipment)
        {
            return await _repository.AddShipmentAsync(shipment);
        }

        public async Task<bool> DeleteShipmentAsync(int id)
        {
            return await _repository.DeleteShipmentAsync(id);
        }

        public async Task<Shipment> GetShipmentAsync(int id)
        {
            return await _repository.GetShipmentAsync(id);
        }

        public async Task<List<Shipment>> GetShipmentsAsync()
        {
            return await _repository.GetShipmentsAsync();
        }

        public async Task<bool> UpdateShipmentAsync(Shipment shipment)
        {
            return await _repository.UpdateShipmentAsync(shipment);
        }
    }
}
