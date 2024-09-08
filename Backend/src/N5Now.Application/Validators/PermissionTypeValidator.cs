using FluentValidation;
using N5Now.Infrastructure.PermissionTypes.Commands;
using N5Now.Domain.DTOs;

namespace N5Now.Application.Validators
{
    public class PermissionTypeValidator : AbstractValidator<PermissionTypeDto>
    {
        public PermissionTypeValidator()
        {
            RuleFor(x => x.Description).NotNull();
        }
    }

    public class CreatePermissionTypeValidator : AbstractValidator<CreatePermissionTypeCommand>
    {
        public CreatePermissionTypeValidator()
        {
            RuleFor(x => x.Description).NotNull();
        }
    }

    public class UpdatePermissionTypeValidator : AbstractValidator<UpdatePermissionTypeCommand>
    {
        public UpdatePermissionTypeValidator()
        {
            RuleFor(x => x.Description).NotNull();
        }
    }
}
