using FluentValidation;
using N5Now.Domain.DTOs;

namespace N5Now.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
