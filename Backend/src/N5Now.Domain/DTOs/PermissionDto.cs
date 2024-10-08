﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.DTOs
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public EmployeeDto Employee { get; set; }
        public PermissionTypeDto PermissionType { get; set; }
        public DateTime? Date { get; set; }
    }
}
