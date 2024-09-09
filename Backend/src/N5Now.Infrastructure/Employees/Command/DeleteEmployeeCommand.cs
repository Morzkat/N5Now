using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.Employees.Command
{
    public class DeleteEmployeeCommand: IRequest
    {
        public int Id { get; set; }
    }
}
