using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class CreateInventoryItemDtoValidator : AbstractValidator<CreateInventoryItemDto>
    {
        public CreateInventoryItemDtoValidator()
        {
            RuleFor(i => i.Sku)
                .NotEmpty().WithMessage("SKU is required");

            RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("Product Id is required");
        }
    }
}
