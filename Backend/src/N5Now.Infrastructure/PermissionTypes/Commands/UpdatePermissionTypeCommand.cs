using MediatR;
using N5Now.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.PermissionTypes.Commands
{
    public class UpdatePermissionTypeCommand : IRequest<PermissionTypeDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
