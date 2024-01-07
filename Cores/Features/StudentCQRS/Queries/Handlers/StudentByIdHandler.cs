using AutoMapper;
using Cores.Abstracts;
using Cores.Features.StudentCQRS.Queries.Models.mapping;
using Cores.Features.StudentCQRS.Queries.Models.requests;
using Cores.Services;
using Data.Entities;
using MediatR;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Queries.Handlers
{
    #region Fields

    #endregion
    public class StudentByIdHandler : IRequestHandler<StudentByIdQuery, StudentlistQueryResponse>
    {

        private readonly IServiceGenaric<Student> _studentService;
        private readonly IMapper mapper1;
        public StudentByIdHandler(IServiceGenaric<Student> studentService, IMapper mapper)
        {
            _studentService = studentService;
            this.mapper1 = mapper;
        }
        public async Task<StudentlistQueryResponse> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByID(request.ID);
            if (student == null) return null;
            var result = mapper1.Map<StudentlistQueryResponse>(student);
            return result;

                

        }
    }
    }

