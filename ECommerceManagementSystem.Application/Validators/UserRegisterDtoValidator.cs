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
        }
    }
}
