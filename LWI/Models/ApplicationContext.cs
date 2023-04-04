using LWI.Views.Lwi;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Data;

namespace LWI.Models
{
    public class ApplicationContext : IdentityDbContext<CourseCreator,IdentityRole,string>
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

            modelBuilder.Entity<Order>()
                .Property(o => o.Country)
                .HasConversion(new EnumToStringConverter<Country>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersToCourses> OrdersToCourses { get; set; }
    }
}
