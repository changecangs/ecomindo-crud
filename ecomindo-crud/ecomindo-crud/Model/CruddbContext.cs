using Microsoft.EntityFrameworkCore;
using ecomindo_crud.Model;

namespace ecomindo_crud.Model
{
    public class CruddbContext : DbContext
    {
        public CruddbContext(DbContextOptions<CruddbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
