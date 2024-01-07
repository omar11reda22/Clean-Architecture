using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Query.Request
{
    public class Departmentlistquery:IRequest<List<Department>>
    {
    }
}
