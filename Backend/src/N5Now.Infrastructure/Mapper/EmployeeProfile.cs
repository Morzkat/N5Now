using AutoMapper;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using N5Now.Infrastructure.Employees.Command;
using N5Now.Infrastructure.Permissions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<DeleteEmployeeCommand, Employee>().ReverseMap();
        }
    }
}
