using Microsoft.EntityFrameworkCore;


namespace E_Book_Trading_Platform.Models
{
    public class PlatformContext :DbContext
    {
        public PlatformContext(DbContextOptions<PlatformContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("admin");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Book>().ToTable("bookinfo");
            modelBuilder.Entity<Order>().ToTable("orderForm");
        }
    }
}
