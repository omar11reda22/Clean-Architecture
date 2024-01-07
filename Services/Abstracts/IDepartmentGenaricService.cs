﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstracts
{
    public interface IDepartmentGenaricService<T>  where T : class
    {
        Task<List<T>> GettallDepartmentlistasync();
    }
}
