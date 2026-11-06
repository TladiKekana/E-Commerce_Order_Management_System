using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> GetPaymentAsync(int id);
        Task<List<Payment>> GetPaymentsAsync();
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
