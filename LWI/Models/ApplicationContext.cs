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
        }

        public DbSet<Course> Courses { get; set; }
    }
}
