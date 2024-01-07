using Cores.Features.StudentCQRS.Command.Mapping;
using Data.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Command.Requests
{
    public record StudentUpdateCommand(int id):IRequest<Student>
    {
       // public int STDID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int DEPTID { get; set; } 


    }
}
