using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            return await _repository.AddPaymentAsync(payment);
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await _repository.DeletePaymentAsync(id);
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _repository.GetPaymentAsync(id);
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _repository.GetPaymentsAsync();
        }

        public async Task<bool> UpdatePaymentAsync(Payment payment)
        {
            return await _repository.UpdatePaymentAsync(payment);
        }
    }
}
