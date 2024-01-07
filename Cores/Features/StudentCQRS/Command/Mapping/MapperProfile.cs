using AutoMapper;
using Cores.Features.StudentCQRS.Command.Requests;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Command.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap<StudentAddInput,Student>().ForMember(des => des.DEPTID , src => src.MapFrom(s => s.DID));

            CreateMap<StudentUpdateCommand, Student>();
        
        }
    }
}
