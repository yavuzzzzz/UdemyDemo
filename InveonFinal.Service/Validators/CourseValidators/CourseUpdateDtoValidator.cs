using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InveonFinal.Service.Dtos.CourseDtos;

namespace InveonFinal.Service.Validators.CourseValidators
{
    public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
    {
        public CourseUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("Duration is required");

            RuleFor(x => x.Price).NotEmpty()
                .GreaterThan(0)
                .WithMessage("Price cannot be smaller than zero");
        }
    }
}
