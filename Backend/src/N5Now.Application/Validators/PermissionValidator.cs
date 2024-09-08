using FluentValidation;
using N5Now.Infrastructure.Permissions.Commands;
using N5Now.Domain.DTOs;
using N5Now.Application.Validators;

namespace N5Now.App.Validators
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.PermissionType).NotNull();
            RuleFor(x => x.PermissionType).SetValidator(new PermissionTypeValidator());
            RuleFor(x => x.Date).NotNull();
        }
    }

    public class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.PermissionType).NotNull();
            RuleFor(x => x.Date).NotNull();
        }
    }

    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCommand>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.PermissionType).NotNull();
            RuleFor(x => x.Date).NotNull();
        }
    }
}
