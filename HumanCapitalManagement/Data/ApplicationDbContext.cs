using Fluent.Infrastructure.FluentModel;
using HumanCapitalManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }


    public DbSet<Login> Logins { get; set; }
    public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    public DbSet<ProjectAssignment> ProjectAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<EmployeeInfo>().HasKey(e => e.EmployeeId);
        modelBuilder.Entity<ProjectAssignment>().HasKey(e => e.AssignmentId);

        base.OnModelCreating(modelBuilder);
    }
}
