using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataBaseFirst.Model;

public partial class Hospital5Context : DbContext
{
    public Hospital5Context()
    {
    }

    public Hospital5Context(DbContextOptions<Hospital5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorsExamination> DoctorsExaminations { get; set; }

    public virtual DbSet<Examination> Examinations { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC077CB17B4C");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F604B21687").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctors__3214EC0707CAE7FE");

            entity.Property(e => e.Premium)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("money");
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        modelBuilder.Entity<DoctorsExamination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorsE__3214EC07B453A05C");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__Docto__4D94879B");

            entity.HasOne(d => d.Examination).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__Exami__4E88ABD4");

            entity.HasOne(d => d.Ward).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__WardI__4F7CD00D");
        });

        modelBuilder.Entity<Examination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Examinat__3214EC0789C6833C");

            entity.HasIndex(e => e.Name, "UQ__Examinat__737584F66FBAB8EF").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wards__3214EC07E7A8A8C2");

            entity.HasIndex(e => e.Name, "UQ__Wards__737584F6DC5F466D").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasOne(d => d.Department).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wards__Departmen__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
