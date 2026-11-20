using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class UpdateSupplierRequestDtoValidator : AbstractValidator<UpdateSupplierRequestDto>
    {
        public UpdateSupplierRequestDtoValidator()
        {
            RuleFor(s => s.SupplierId)
                .NotEmpty().WithMessage("Supplier Id required.");

            RuleFor(s => s.SupplierName)
                .NotEmpty().WithMessage("Supplier name required.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Supplier email required.");
        }
    }
}
