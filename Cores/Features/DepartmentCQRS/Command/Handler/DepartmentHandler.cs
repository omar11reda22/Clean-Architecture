using AutoMapper;
using Cores.Features.DepartmentCQRS.Command.Request;
using Data.Entities;
using MediatR;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Command.Handler
{
    public class DepartmentHandler : IRequestHandler<DepartmentADDCommand, Department>,
                                   IRequestHandler<DepartmentremoveCommand,Department>
    {
        private readonly IMapper mapper;
        private readonly IServiceGenaric<Department> serviceGenaric;
        public DepartmentHandler(IMapper mapper, IServiceGenaric<Department> serviceGenaric)
        {
            this.mapper = mapper;
            this.serviceGenaric = serviceGenaric;
        }

      
        public Task<Department> Handle(DepartmentADDCommand request, CancellationToken cancellationToken)
        {
            var item = mapper.Map<Department>(request.DepartmentAddDTO);
            var result = serviceGenaric.add(item);
            return result;
        }

        public async Task<Department> Handle(DepartmentremoveCommand request, CancellationToken cancellationToken)
        {
          
            var item = await serviceGenaric.remove(request.id);
            return item;
        }
    }
}
