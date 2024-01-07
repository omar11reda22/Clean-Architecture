using Cores.Features.StudentCQRS.Command.Mapping;
using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Command.Requests
{
    public record StudentAddCommand(StudentAddInput StudentAdd) :IRequest<Student>
    {
    }
}
