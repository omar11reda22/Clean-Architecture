using Cores.Features.DepartmentCQRS.Query.Request;
using Data.Entities;
using MediatR;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Query.Handler
{
    public class Departmentthandler : IRequestHandler<Departmentlistquery, List<Department>>,
        IRequestHandler<DepartmentGetbyidQuery , Department>

    {
        private readonly IServiceGenaric<Department> _serviceGenaric;

        public Departmentthandler(IServiceGenaric<Department> serviceGenaric)
        {
            _serviceGenaric = serviceGenaric;
        }

        public Task<List<Department>> Handle(Departmentlistquery request, CancellationToken cancellationToken)
        {
            var items = _serviceGenaric.Getallvalue();
            return items;
        }

        public Task<Department> Handle(DepartmentGetbyidQuery request, CancellationToken cancellationToken)
        {
            var item = _serviceGenaric.GetByID(request.id);
            if (item == null) return null;
            return item;
        }
    }
}
