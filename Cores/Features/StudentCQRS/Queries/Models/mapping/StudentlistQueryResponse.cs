using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Queries.Models.mapping
{
    public class StudentlistQueryResponse
    {
        public int STDID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
