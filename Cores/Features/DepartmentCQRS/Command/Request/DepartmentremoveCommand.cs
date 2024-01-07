using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Command.Request
{
    public record DepartmentremoveCommand(int id):IRequest<Department>
    {
    }
}
