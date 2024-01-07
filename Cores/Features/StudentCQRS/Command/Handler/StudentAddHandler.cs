using AutoMapper;
using Cores.Abstracts;
using Cores.Features.StudentCQRS.Command.Mapping;
using Cores.Features.StudentCQRS.Command.Requests;
using Data.Entities;
using MediatR;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Command.Handler
{
    public class StudentAddHandler : IRequestHandler<StudentAddCommand , Student>,
                                     IRequestHandler<StudentRemoveCommand,Student>,
                                     IRequestHandler<StudentUpdateCommand,Student>
                                    
    {
        private readonly IServiceGenaric<Student> _studentService;
        private readonly IMapper mapper;
        public StudentAddHandler(IServiceGenaric<Student> studentService, IMapper mapper)
        {
            _studentService = studentService;
            this.mapper = mapper;
        }

        public async Task Handle(StudentAddCommand request, CancellationToken cancellationToken)
        {
            var result =  mapper.Map<Student>(request.StudentAdd);
                      _studentService.add(result);

            //var student = await _studentService.add(request.StudentAdd);
            //var result = mapper.Map<Student>(student);
            return ;

        }

        public Task<Student> Handle(StudentRemoveCommand request, CancellationToken cancellationToken)
        {
            var result = _studentService.remove(request.id);
            return result;
        }

        public async Task<Student> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            var result =await _studentService.GetByID(request.id);
            if (result == null)
                return null;
            var item = mapper.Map<Student>(request);
            var final = await _studentService.update(request.id , item);
            return final;
        }

        async Task<Student> IRequestHandler<StudentAddCommand, Student>.Handle(StudentAddCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Student>(request.StudentAdd);
                           await _studentService.add(result);
            return result;

        }
    }
}
