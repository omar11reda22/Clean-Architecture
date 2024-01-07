using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            
        }
        public ApplicationContext(DbContextOptions options):base(options) 
        {
            
        }
        #region configuration [one to many] relation [Fluentapi]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(s => s.Students)
                .WithOne(s => s.department)
                .HasForeignKey(s => s.DEPTID)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Tables will mapping in DB
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion

    }
}
