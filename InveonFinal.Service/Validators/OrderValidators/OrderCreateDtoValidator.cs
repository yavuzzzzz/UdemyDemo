using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.OrderDtos;

namespace InveonFinal.Service.Validators.OrderValidators
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.OrderDetails).NotEmpty().WithMessage("OrderDetails is required");

            RuleForEach(x => x.OrderDetails).SetValidator(new OrderDetailDtoValidator());
        }
    }
}
