using Microsoft.EntityFrameworkCore;
using ecomindo_crud.Model;

namespace ecomindo_crud.Model
{
    public class CruddbContext : DbContext
    {
        //private const string connectionString = "Server=tcp:onboarding-ecom.database.windows.net,1433;Initial Catalog=onboarding-db;Persist Security Info=False;User ID=onboarding;Password=P@ssw0rd1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public CruddbContext(DbContextOptions<CruddbContext> options) : base(options){ }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
