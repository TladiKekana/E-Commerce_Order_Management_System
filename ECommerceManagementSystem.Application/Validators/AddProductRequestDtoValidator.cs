using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;

namespace ECommerceManagementSystem.Application.Validators
{
    public class AddProductRequestDtoValidator : AbstractValidator<AddProductRequestDto>
    {
        public AddProductRequestDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product Name cannot be empty")
                .MaximumLength(150);

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
