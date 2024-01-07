using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstracts
{
    public interface IServiceGenaric<T> where T : class
    {
        Task<List<T>> Getallvalue();
        Task<T> GetByID(int id);

        Task<T> add(T model);
        Task<T> remove(int id);
        Task<T> update(int id ,T model);
    }
}
