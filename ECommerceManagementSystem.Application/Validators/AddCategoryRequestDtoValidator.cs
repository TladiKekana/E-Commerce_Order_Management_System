using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;

namespace ECommerceManagementSystem.Application.Validators
{
    public class AddCategoryRequestDtoValidator : AbstractValidator<AddCategoryRequestDto>
    {
        public AddCategoryRequestDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name cannot be empty");
        }
    }
}
