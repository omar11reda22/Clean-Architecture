using AutoMapper;
using Cores.Abstracts;
using Cores.Features.StudentCQRS.Queries.Models.mapping;
using Cores.Features.StudentCQRS.Queries.Models.requests;
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
    public class StudentlistHandler : 
        IRequestHandler<StudentlistQuery,  List<StudentlistQueryResponse>>
        

    {
        #region Fields
        private readonly IServiceGenaric<Student> _studentService;
        private readonly IMapper mapper;
        public StudentlistHandler(IServiceGenaric<Student> studentService, IMapper mapper)
        {
            _studentService = studentService;
            this.mapper = mapper;
        }



        #endregion
        public async Task<List<StudentlistQueryResponse>> Handle(StudentlistQuery request, CancellationToken cancellationToken)
        {
            var studentlist = await _studentService.Getallvalue();
            var result =  mapper.Map<List<StudentlistQueryResponse>>(studentlist);
            
            return result;
        }

      
    }
}
