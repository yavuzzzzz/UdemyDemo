using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.UserDtos;

namespace InveonFinal.Service.Validators.UserValidators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
                .MinimumLength(6).WithMessage("First Name must be at least 6 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required")
                .MinimumLength(6).WithMessage("Last Name must be at least 6 characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(12)
                .WithMessage("Password must be at least 12 characters.")
                .Must(BeAlphanumeric)
                .WithMessage("Password must contain alphanumeric characters");
            
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match");
        }
        private bool BeAlphanumeric(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).+$");
        }



    }
}

