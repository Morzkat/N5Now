﻿using Moq;
using AutoMapper;
using N5Now.Domain;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using System.Linq.Expressions;
using N5Now.Domain.Repositories;
using N5Now.Application.Services;
using N5Now.Domain.Common.Exceptions;
using N5Now.Domain.Services;
using N5Now.Application.Producer.Kafka;

namespace N5Now.Tests.Services
{
    public class PermissionServiceTests
    {
        [Test]
        public void GetPermission_PermissionNotFound_Should_ThrowsNotFoundException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();
            //var elasticSearch = new Mock<IElasticsearchService>();

            var service = new PermissionService(unitOfWorkMock.Object, null, null, null);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(false);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            // Act => Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.GetPermission(1), "The permission doesn't exist");
        }

        [Test]
        public async Task GetPermission_PermissionFound_Should_ReturnsPermission()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();
            var mapperMock = new Mock<IMapper>();
            const int permissionId = 1;

            var permission = new Permission
            {
                Id = permissionId,
            };

            var permissionDto = new PermissionDto();

            var service = new PermissionService(unitOfWorkMock.Object, mapperMock.Object, null, null);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(true);

            permissionRepositoryMock.Setup(x => x.GetByIdAsync(permissionId, It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(permission);

            mapperMock.Setup(x => x.Map<PermissionDto>(permission))
                .Returns(permissionDto);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            // Act 
            var result = await service.GetPermission(permissionId);

            // Assert
            Assert.That(permissionDto, Is.EqualTo(result));
        }



        [Test]
        public void UpdatePermission_PermissionNotFound_Should_ThrowsConflictException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();

            var permission = new Permission
            {
                Id = 1,
            };

            var service = new PermissionService(unitOfWorkMock.Object, null, null, null);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(false);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            // Act => Assert
            Assert.ThrowsAsync<ConflictException>(() => service.UpdatePermission(permission), "The permission doesn't exist");
        }

        [Test]
        public void UpdatePermission_PermissionTypeNotFound_Should_ThrowsConflictException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();
            var permissionTypeRepositoryMock = new Mock<IPermissionTypeRepository>();
            var employeeRepositoryMock = new Mock<IEmployeesRepository>();
            var elasticsearchServiceMock = new Mock<IElasticsearchService>();
            var producerServiceMock = new Mock<IProducerService<OperationMessage>>();

            var mapperMock = new Mock<IMapper>();

            var permission = new Permission
            {
                Id = 1,
                PermissionType = new PermissionType
                {
                    Id = 2,
                    Description = "PermissionType 1",
                },
                Employee = new Employee
                {
                    Id = 1,
                    Name = "Test",
                    LastName = "Test",
                }
            };

            var service = new PermissionService(unitOfWorkMock.Object, mapperMock.Object, elasticsearchServiceMock.Object, producerServiceMock.Object);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(true);

            employeeRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Employee, bool>>>()))
              .ReturnsAsync(true);

            permissionTypeRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<PermissionType, bool>>>()))
                .ReturnsAsync(false);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            unitOfWorkMock.Setup(v => v.PermissionTypeRepository)
                .Returns(permissionTypeRepositoryMock.Object);

            unitOfWorkMock.Setup(v => v.EmployeeRepository)
               .Returns(employeeRepositoryMock.Object);

            elasticsearchServiceMock.Setup(v => v.AddOrUpdate(It.IsAny<object>(), It.IsAny<string>()));
            producerServiceMock.Setup(v => v.Publish(It.IsAny<OperationMessage>()));

            // Act => Assert
            Assert.ThrowsAsync<ConflictException>(() => service.UpdatePermission(permission), "The permission type doesn't exist.");
        }

        [Test]
        public async Task UpdatePermission_PermissionAndPermissionTypeFound_Should_UpdatePermission()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();
            var permissionTypeRepositoryMock = new Mock<IPermissionTypeRepository>();
            var employeeRepositoryMock = new Mock<IEmployeesRepository>();
            var elasticsearchServiceMock = new Mock<IElasticsearchService>();
            var producerServiceMock = new Mock<IProducerService<OperationMessage>>();

            var mapperMock = new Mock<IMapper>();

            var permission = new Permission
            {
                Id = 1,
                PermissionType = new PermissionType
                {
                    Id = 2,
                    Description = "PermissionType 1"
                },
                Employee = new Employee
                {
                    Id = 1,
                    Name = "Test",
                    LastName = "Test",
                }
            };

            var service = new PermissionService(unitOfWorkMock.Object, mapperMock.Object, elasticsearchServiceMock.Object, producerServiceMock.Object);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(true);

            permissionTypeRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<PermissionType, bool>>>()))
                .ReturnsAsync(true);

            employeeRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Employee, bool>>>()))
                .ReturnsAsync(true);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            unitOfWorkMock.Setup(v => v.PermissionTypeRepository)
                .Returns(permissionTypeRepositoryMock.Object);

            unitOfWorkMock.Setup(v => v.EmployeeRepository)
                .Returns(employeeRepositoryMock.Object);

            elasticsearchServiceMock.Setup(v => v.AddOrUpdate(It.IsAny<object>(), It.IsAny<string>() ));
            producerServiceMock.Setup(v => v.Publish(It.IsAny<OperationMessage>()));

            // Act
            await service.UpdatePermission(permission);

            // Assert
            permissionRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Permission>()));
            unitOfWorkMock.Verify(x => x.SaveAsync());
        }



        [Test]
        public void DeletePermission_PermissionNotFound_Should_ThrowsNotFoundException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();

            var service = new PermissionService(unitOfWorkMock.Object, null, null, null);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(false);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            // Act => Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.DeletePermission(1), "The permission doesn't exist");
        }

        [Test]
        public async Task DeletePermission_PermissionFound_Should_DeletePermission()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var permissionRepositoryMock = new Mock<IPermissionRepository>();
            var mapperMock = new Mock<IMapper>();
            const int permissionId = 1;

            var permission = new Permission
            {
                Id = permissionId,
            };

            var service = new PermissionService(unitOfWorkMock.Object, mapperMock.Object, null, null);

            permissionRepositoryMock.Setup(v => v.ExistAsync(It.IsAny<Expression<Func<Permission, bool>>>()))
                .ReturnsAsync(true);

            permissionRepositoryMock.Setup(x => x.GetByIdAsync(permissionId, It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(permission);

            unitOfWorkMock.Setup(v => v.PermissionRepository)
                .Returns(permissionRepositoryMock.Object);

            // Act 
            await service.DeletePermission(permissionId);

            // Assert
            permissionRepositoryMock.Verify(x => x.DeleteAsync(permission));
            unitOfWorkMock.Verify(x => x.SaveAsync());
        }
    }
}
