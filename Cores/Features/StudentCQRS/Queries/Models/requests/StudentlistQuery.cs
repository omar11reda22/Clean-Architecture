using Cores.Features.StudentCQRS.Queries.Models.mapping;
using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Queries.Models.requests
{
    public class StudentlistQuery : IRequest<List<StudentlistQueryResponse>>
    {
    }
}
