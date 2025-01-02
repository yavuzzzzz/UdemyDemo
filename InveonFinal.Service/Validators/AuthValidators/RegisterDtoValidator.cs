using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.AuthDtos;

namespace InveonFinal.Service.Validators.AuthValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email).
                NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email is required.");

            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(12)
                .WithMessage("Password must be at least 12 characters.")
                .Must(BeAlphanumeric)
                .WithMessage("Password must contain alphanumeric characters");


            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                .WithMessage("Passwords must match.");

        }
        private bool BeAlphanumeric(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).+$");
        }

    }
}
