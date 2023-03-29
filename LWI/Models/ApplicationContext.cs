using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LWI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(o => o.Price)
                .HasColumnType(SqlDbType.Money.ToString());

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasColumnType(SqlDbType.Money.ToString());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersToCourses> OrdersToCourses { get; set; }
    }
}
