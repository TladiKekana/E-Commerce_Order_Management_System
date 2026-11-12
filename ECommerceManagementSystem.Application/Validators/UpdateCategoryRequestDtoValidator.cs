using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;

namespace ECommerceManagementSystem.Application.Validators
{
    public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
    {
        public UpdateCategoryRequestDtoValidator()
        {
            RuleFor(c => c.Category_Id)
                .NotEmpty().WithMessage("Category Id cannot be empty");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name cannot be empty");
        }
    }
}
