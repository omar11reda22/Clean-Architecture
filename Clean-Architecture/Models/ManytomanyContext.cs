using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Models;

public partial class ManytomanyContext : DbContext
{
    public ManytomanyContext()
    {
    }

    public ManytomanyContext(DbContextOptions<ManytomanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=manytomany;Integrated Security=True;Encrypt=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CntId);

            entity.Property(e => e.CntId).HasColumnName("CNT_ID");
            entity.Property(e => e.CntName).HasColumnName("CNT_Name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CrsId);

            entity.ToTable(tb => tb.HasTrigger("t1"));

            entity.Property(e => e.CrsId).HasColumnName("CRS_ID");
            entity.Property(e => e.CrsName).HasColumnName("CRs_Name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.HasIndex(e => e.CnrId, "IX_Students_CNR_ID");

            entity.Property(e => e.StdId).HasColumnName("STD_ID");
            entity.Property(e => e.CnrId).HasColumnName("CNR_ID");
            entity.Property(e => e.StdEmail)
                .HasMaxLength(100)
                .HasColumnName("STd_Email");
            entity.Property(e => e.StdName)
                .HasMaxLength(100)
                .HasColumnName("STD_Name");

            entity.HasOne(d => d.Cnr).WithMany(p => p.Students).HasForeignKey(d => d.CnrId);

            entity.HasMany(d => d.Crs).WithMany(p => p.Stds)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CrsId"),
                    l => l.HasOne<Student>().WithMany().HasForeignKey("StdId"),
                    j =>
                    {
                        j.HasKey("StdId", "CrsId");
                        j.ToTable("StudentCourses");
                        j.HasIndex(new[] { "CrsId" }, "IX_StudentCourses_CRS_ID");
                        j.IndexerProperty<int>("StdId").HasColumnName("STD_ID");
                        j.IndexerProperty<int>("CrsId").HasColumnName("CRS_ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
