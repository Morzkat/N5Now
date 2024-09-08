using N5Now.Domain.DTOs;
using FluentValidation.TestHelper;
using N5Now.App.Validators;

namespace N5Now.Tests.Validators
{
    [TestFixture]
    public class PermissionValidatorTests
    {
        private PermissionValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new PermissionValidator();
        }

        [Test]
        public void Should_have_error_when_Name_is_null()
        {
            var model = new PermissionDto { Name = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(p => p.Name);
        }

        [Test]
        public void Should_not_have_error_when_Name_is_specified()
        {
            var model = new PermissionDto { Name = "Jadhiel" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(p => p.Name);
        }

        [Test]
        public void Should_have_error_when_LastName_is_null()
        {
            var model = new PermissionDto { LastName = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(p => p.LastName);
        }

        [Test]
        public void Should_not_have_error_when_LastName_is_specified()
        {
            var model = new PermissionDto { LastName = "Vélez" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(p => p.LastName);
        }

        [Test]
        public void Should_have_error_when_PermissionType_is_null()
        {
            var model = new PermissionDto { PermissionType = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(p => p.PermissionType);
        }

        [Test]
        public void Should_not_have_error_when_PermissionType_is_specified()
        {
            var model = new PermissionDto
            {
                PermissionType = new PermissionTypeDto
                {
                    Id = 3,
                    Description = "Otros"
                }
            };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(p => p.PermissionType);
        }

        [Test]
        public void Should_have_error_when_Date_is_null()
        {
            var model = new PermissionDto { Date = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(p => p.Date);
        }

        [Test]
        public void Should_not_have_error_when_Date_is_specified()
        {
            var model = new PermissionDto { Date = DateTime.Now };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(p => p.Date);
        }
    }
}
