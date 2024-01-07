using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.DepartmentCQRS.Command.Mapping
{
    public class Mappingprofile:Profile
    {
        public Mappingprofile()
        {
            CreateMap<DepartmentAddDTO, Department>();
        }
    }
}
