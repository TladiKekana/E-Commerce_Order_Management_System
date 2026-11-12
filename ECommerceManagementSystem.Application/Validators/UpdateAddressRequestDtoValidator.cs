using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;

namespace ECommerceManagementSystem.Application.Validators
{
    public class UpdateAddressRequestDtoValidator : AbstractValidator<UpdateAddressRequestDto>
    {
        public UpdateAddressRequestDtoValidator()
        {
            RuleFor(a => a.Address_Id)
                .NotEmpty().WithMessage("Address Id cannot be empty");

            RuleFor(a => a.Address_Type)
                .NotEmpty().WithMessage("Address type cannot be empty");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("City cannot be empty");

            RuleFor(a => a.Province)
                .NotEmpty().WithMessage("Province cannot be empty");

            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("Country cannot be empty");

            RuleFor(a => a.Posta_Code)
                .NotEmpty().WithMessage("Postal code cannot be empty");

            RuleFor(a => a.Street_Address)
                .NotEmpty().WithMessage("Street address cannot be empty");

            RuleFor(a => a.User_Id)
                .NotEmpty().WithMessage("User Id cannot be empty");
        }
    }
}
