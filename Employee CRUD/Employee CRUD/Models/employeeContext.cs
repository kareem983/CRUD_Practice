using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Employee_CRUD.Models
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
            : base("name=employeeContext")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Government> Governments { get; set; }
        public virtual DbSet<village> villages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.dept_id);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.villages)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.dept_id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.national_id)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.phone_number)
                .IsFixedLength();

            modelBuilder.Entity<Government>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Government)
                .HasForeignKey(e => e.gov_id);

            modelBuilder.Entity<Government>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Government)
                .HasForeignKey(e => e.gov_id);

            modelBuilder.Entity<village>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.village)
                .HasForeignKey(e => e.village_id);
        }
    }
}
