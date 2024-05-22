using System;
using System.Collections.Generic;

namespace Clean_Architecture.Models;

public partial class Course
{
    public int CrsId { get; set; }

    public string CrsName { get; set; } = null!;

    public virtual ICollection<Student> Stds { get; set; } = new List<Student>();
}
