using Data.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DepartmentService : IServiceGenaric<Department>
    {
        private readonly ApplicationContext context;

        public DepartmentService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Department> add(Department model)
        {
           await context.Departments.AddAsync(model);
            context.SaveChanges();
            return model;
        }

        public async Task<List<Department>> Getallvalue()
        {
           var listdept = await context.Departments.AsNoTracking().ToListAsync();
            return listdept;
        }

        public async Task<Department> GetByID(int id)
        {
            var item = await context.Departments.SingleOrDefaultAsync(s => s.DEPTID == id);
            return item;
        }

        public async Task<Department> remove(int id)
        {
            var item =await context.Departments.SingleOrDefaultAsync(s => s.DEPTID == id);
            context.Departments.Remove(item);   
            context.SaveChanges();
            return item;

        }

        public Task<Department> update(int id, Department model)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Department>> Getallvalue()
        //{
        //  return await context.Departments.AsNoTracking().ToListAsync();
        //}

        //public async Task<Department> GetByID(int id)
        //{
        //   var item = await context.Departments.FirstOrDefaultAsync(s => s.DEPTID == id);
        //    return item;
        //}
    }
}
