using Cores.Abstracts;
using Data.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Services
{
    public class StudentService : IServiceGenaric<Student>
    {
        #region private fields
        private readonly ApplicationContext context;
        #endregion
        #region CTOR

        public StudentService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Student> add(Student model)
        {
            context.Students.Add(model);
            context.SaveChanges();
            return model;
        }




        #endregion

        public async Task<List<Student>> Getallvalue()
        {
           return await context.Students.Include(s => s.department).AsNoTracking().ToListAsync();
           
        }

        public async Task<Student> GetByID(int id)
        {
            var item =  await context.Students.Include(x => x.department). FirstOrDefaultAsync(s => s.STDID == id);
           
            return item;
        }

        public async Task<Student> remove(int id)
        {
            var item =await context.Students.FirstOrDefaultAsync(s => s.STDID == id);
            context.Students.Remove(item);
            context.SaveChanges();
            return item; 

        }

        public Task<Student> update(int id, Student model)
        {
            var item = context.Students.FirstOrDefaultAsync(s => s.STDID == id);
            context.Students.Update(model);
            context.SaveChanges();
            return item;
        }
    }
}
