using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.PaymentDtos;

namespace InveonFinal.Service.Validators.PaymentValidators
{
    public class PaymentCreateDtoValidator : AbstractValidator<PaymentCreateDto>
    {
        public PaymentCreateDtoValidator() 
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
            RuleFor(x => x.Amount).NotEmpty()
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0");
                


        }

    }
}
