using Microsoft.EntityFrameworkCore;
namespace TestingProject.Models

{
    public class ShippingContext:DbContext
    {

        public ShippingContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Role> roles { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Delivery> deliveries { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<Branch> branches { get; set; }
        public DbSet<Governorate> governorates { get; set; }
        public DbSet<City> cities { get; set; }

        public DbSet<Weight> weights { get; set; }

        public DbSet<Product> products { get; set; }
    }
}
