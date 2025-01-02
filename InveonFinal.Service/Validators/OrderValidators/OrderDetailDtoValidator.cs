using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.OrderDtos;

namespace InveonFinal.Service.Validators.OrderValidators
{
    public class OrderDetailDtoValidator : AbstractValidator<OrderDetailDto>
    {
        public OrderDetailDtoValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("CourseId is required");

            RuleFor(x => x.Quantity).NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity cannot be smaller than zero");

            RuleFor(x => x.Price).NotEmpty()
                .GreaterThan(0)
                .WithMessage("Price cannot be smaller than zero");
        }
    }
}
