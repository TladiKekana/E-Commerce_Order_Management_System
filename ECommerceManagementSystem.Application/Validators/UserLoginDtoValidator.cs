using ECommerceManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password required");
        }
    }
}
