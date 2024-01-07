using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Department
    {
        [Key]
        public int DEPTID { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
