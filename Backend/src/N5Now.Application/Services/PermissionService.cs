using AutoMapper;
using N5Now.Domain;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using N5Now.Domain.Services;
using N5Now.Domain.Common.Exceptions;
using N5Now.Application.Producer.Kafka;

namespace N5Now.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IProducerService<OperationMessage> _kafkaProducer;

        public PermissionService(IUnitOfWork unitOfWork, IMapper mapper, IElasticsearchService elasticsearchService, IProducerService<OperationMessage> kafkaProducer)
        {
            _mapper = mapper;
            _elasticsearchService = elasticsearchService;
            _kafkaProducer = kafkaProducer;
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionDto> AddPermission(Permission permission)
        {
            var permissionTypeExist = await _unitOfWork.PermissionTypeRepository.ExistAsync(x => x.Id == permission.PermissionType.Id);
            if (!permissionTypeExist)
                throw new ConflictException("The permission type doesn't exist.");

            permission.PermissionType = await _unitOfWork.PermissionTypeRepository.GetByIdAsync(permission.PermissionType.Id);
            await _unitOfWork.PermissionRepository.AddAsync(permission);
            await _unitOfWork.SaveAsync();
            await _elasticsearchService.AddOrUpdate(permission, permission.Id.ToString());
            //await _kafkaProducer.Publish(new OperationMessage(Operation.request));

            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<PermissionDto> UpdatePermission(Permission permission)
        {
            var exists = await _unitOfWork.PermissionRepository.ExistAsync(x => x.Id == permission.Id);
            if (!exists)
                throw new ConflictException("The permission doesn't exist");

            var permissionTypeExist = await _unitOfWork.PermissionTypeRepository.ExistAsync(x => x.Id == permission.PermissionType.Id);
            if (!permissionTypeExist)
                throw new ConflictException("The permission type doesn't exist.");

            permission.PermissionType = await _unitOfWork.PermissionTypeRepository.GetByIdAsync(permission.PermissionType.Id);
            await _unitOfWork.PermissionRepository.UpdateAsync(permission);
            await _unitOfWork.SaveAsync();
            await _elasticsearchService.AddOrUpdate(permission, permission.Id.ToString());
            //await _kafkaProducer.Publish(new OperationMessage(Operation.modify));

            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task DeletePermission(int permissionId)
        {
            var exists = await _unitOfWork.PermissionRepository.ExistAsync(x => x.Id == permissionId);
            if (!exists)
                throw new NotFoundException("The permission doesn't exist.");

            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionId);
            await _unitOfWork.PermissionRepository.DeleteAsync(permission);
            await _unitOfWork.SaveAsync();
        }

        public async Task<PermissionDto> GetPermission(int permissionId)
        {
            var exists = await _unitOfWork.PermissionRepository.ExistAsync(x => x.Id == permissionId);
            if (!exists)
                throw new NotFoundException("The permission doesn't exist.");

            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionId, new List<string> { "PermissionType" });
            var permissionDto = _mapper.Map<PermissionDto>(permission);

            return permissionDto;
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissions()
        {
            var permissions = await _unitOfWork.PermissionRepository.GetAllAsync(entitiesToInclude: new List<string> { "PermissionType" });
            var permissionsDto = _mapper.Map<IEnumerable<PermissionDto>>(permissions);

           // await _kafkaProducer.Publish(new OperationMessage(Operation.get));

            return permissionsDto;
        }
    }
}
