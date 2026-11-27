using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class RecordTransactionDtoValidator : AbstractValidator<RecordTransactionDto>
    {
        public RecordTransactionDtoValidator()
        {
            RuleFor(rt => rt.InventoryItemId)
                .NotEmpty().WithMessage("InventoryItem Id is required");

            RuleFor(rt => rt.Type)
                .NotEmpty().WithMessage("Transaction type is required");
        }
    }
}
