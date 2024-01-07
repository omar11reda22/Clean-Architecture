using Data.Entities;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> getallstudentasync();
    }
}
