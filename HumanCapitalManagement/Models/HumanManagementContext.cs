using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HumanCapitalManagement.Models
{
    public partial class HumanManagementContext : DbContext
    {
        public HumanManagementContext()
        {
        }

        public HumanManagementContext(DbContextOptions<HumanManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<ProjectAssignment> ProjectAssignments { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=HumanManagement;Username=postgres;Password=13022001");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("city_id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CityName).HasColumnName("city_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");

                entity.Property(e => e.DepartmentName).HasColumnName("department_name");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("assignment_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("position_id");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EmployeeInfo_pkey");

                entity.ToTable("EmployeeInfo");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EmployementId).HasColumnName("employement_id");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.SalaryId).HasColumnName("salary_id");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("city_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("department_id");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("gender_id");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.SalaryId)
                    .HasConstraintName("salary_id");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("gender_id");

                entity.Property(e => e.GenderName).HasColumnName("gender_name");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.LoginId)
                    .ValueGeneratedNever()
                    .HasColumnName("login_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("employee_id");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("position_id");

                entity.Property(e => e.PositionName).HasColumnName("position_name");
            });

            modelBuilder.Entity<ProjectAssignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId)
                    .HasName("ProjectAssignment_pkey");

                entity.ToTable("ProjectAssignment");

                entity.Property(e => e.AssignmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("assignment_id");

                entity.Property(e => e.ProjectDescription).HasColumnName("project_description");

                entity.Property(e => e.ProjectEndDate).HasColumnName("project_end_date");

                entity.Property(e => e.ProjectName).HasColumnName("project_name");

                entity.Property(e => e.ProjectStartDate).HasColumnName("project_start_date");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.SalaryId)
                    .ValueGeneratedNever()
                    .HasColumnName("salary_id");

                entity.Property(e => e.Salary1).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
