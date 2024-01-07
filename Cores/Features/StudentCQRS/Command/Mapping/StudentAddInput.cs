using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Features.StudentCQRS.Command.Mapping
{
    public class StudentAddInput
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int DID { get; set; }
    }
}
