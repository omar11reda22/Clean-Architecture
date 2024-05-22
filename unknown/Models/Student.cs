using System;
using System.Collections.Generic;

namespace unknown.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string StdEmail { get; set; } = null!;

    public int CnrId { get; set; }

    public virtual Country Cnr { get; set; } = null!;

    public virtual ICollection<Course> Crs { get; set; } = new List<Course>();
}
