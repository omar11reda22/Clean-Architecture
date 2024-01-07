using AutoMapper;
using Cores.Features.StudentCQRS.Queries.Models.mapping;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Mapper
{
    public class Mapperprofile:Profile 
    {
        public Mapperprofile()
        {
            //CreateMap<sourse>(destnation) destnation to source
            CreateMap<Student, StudentlistQueryResponse>()
                .ForMember(dest => dest.DepartmentName, src => src.MapFrom(s => s.department.Name));
        }
    }
}
