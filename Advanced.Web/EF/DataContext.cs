using Advanced.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Web.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Person> People { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}