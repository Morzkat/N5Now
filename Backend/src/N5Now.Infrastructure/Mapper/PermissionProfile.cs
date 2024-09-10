using AutoMapper;
using N5Now.Infrastructure.Permissions.Commands;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;

namespace N5Now.Infrastructure.Mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDto, Permission>().ReverseMap();
            CreateMap<CreatePermissionCommand, Permission>()
                .ForPath(dest => dest.PermissionType.Id, opt => opt.MapFrom(src => src.PermissionType))
                .ForPath(dest => dest.Employee.Id, opt => opt.MapFrom(src => src.Employee))
                .ReverseMap();
            CreateMap<UpdatePermissionCommand, Permission>()
                .ForPath(dest => dest.PermissionType.Id, opt => opt.MapFrom(src => src.PermissionType))
                .ForPath(dest => dest.Employee.Id, opt => opt.MapFrom(src => src.Employee))
                .ReverseMap();
            CreateMap<DeletePermissionCommand, Permission>()
                .ReverseMap();
            CreateMap<PermissionTypeDto, PermissionType>().ReverseMap();
        }
    }
}
