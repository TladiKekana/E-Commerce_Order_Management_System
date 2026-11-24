using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(u => u.First_Name)
                .NotEmpty().WithMessage("First Name required");

            RuleFor(u => u.Last_Name)
                .NotEmpty().WithMessage("First Name required");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("First Name required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("First Name required");

            RuleFor(u => u.StreetAddress)
                .NotEmpty().WithMessage("Street address required");

            RuleFor(u => u.City)
                .NotEmpty().WithMessage("City Name required");

            RuleFor(u => u.Province)
                .NotEmpty().WithMessage("Province required");

            RuleFor(u => u.PostalCode)
                .NotEmpty().WithMessage("Postal code required");

            RuleFor(u => u.Country)
                .NotEmpty().WithMessage("Country Name required");
        }
    }
}
