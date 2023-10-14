﻿using HumanCapitalManagement.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    // Define DbSet properties for your entities
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    public DbSet<ProjectAssignment> ProjectAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity relationships and other model configurations here

        // Example:
        // modelBuilder.Entity<YourEntity>()
        //     .HasKey(e => e.Id);
        // modelBuilder.Entity<YourEntity>()
        //     .Property(e => e.SomeProperty)
        //     .IsRequired();
        modelBuilder.Entity<EmployeeInfo>().HasKey(e => e.EmployeeId);
        modelBuilder.Entity<ProjectAssignment>().HasKey(e => e.AssignmentId);

        base.OnModelCreating(modelBuilder);
    }
}
