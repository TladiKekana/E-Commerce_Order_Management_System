using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<Shipment> GetShipmentAsync(int id);
        Task<List<Shipment>> GetShipmentsAsync();
        Task<Shipment> AddShipmentAsync(Shipment shipment);
        Task<bool> UpdateShipmentAsync(Shipment shipment);
        Task<bool> DeleteShipmentAsync(int id);
    }
}
