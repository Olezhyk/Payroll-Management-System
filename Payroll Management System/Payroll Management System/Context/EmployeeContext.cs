namespace Payroll_Management_System.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Payroll_Management_System.Entities;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }        

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalaryInfo> Salaries { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}