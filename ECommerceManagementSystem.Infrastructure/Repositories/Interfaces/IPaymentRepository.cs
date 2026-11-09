using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentAsync(int id);
        Task<List<Payment>> GetPaymentsAsync();
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
