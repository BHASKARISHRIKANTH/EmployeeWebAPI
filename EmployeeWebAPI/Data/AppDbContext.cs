using EmployeeWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
