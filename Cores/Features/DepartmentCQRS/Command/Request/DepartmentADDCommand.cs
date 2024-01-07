using Cores.Features.DepartmentCQRS.Command.Mapping;
using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Command.Request
{
    public record DepartmentADDCommand(DepartmentAddDTO DepartmentAddDTO):IRequest<Department>
    {
    }
}
