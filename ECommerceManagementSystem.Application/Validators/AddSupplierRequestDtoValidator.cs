using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class AddSupplierRequestDtoValidator : AbstractValidator<AddSupplierRequestDto>
    {
        public AddSupplierRequestDtoValidator()
        {
            RuleFor(s => s.SupplierName)
                .NotEmpty().WithMessage("Supplier name required.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Supplier email required.");
        }
    }
}
