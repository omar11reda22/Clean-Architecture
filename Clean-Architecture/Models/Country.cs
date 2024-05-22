using System;
using System.Collections.Generic;

namespace Clean_Architecture.Models;

public partial class Country
{
    public int CntId { get; set; }

    public string CntName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
