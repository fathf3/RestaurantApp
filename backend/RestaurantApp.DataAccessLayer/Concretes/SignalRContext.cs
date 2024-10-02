using Microsoft.EntityFrameworkCore;
using RestaurantApp.EntityLayer.Entities;
using System.Reflection;

namespace RestaurantApp.DataAccessLayer.Concretes
{
    public class SignalRContext : DbContext
    {
        public SignalRContext()
        {

        }
        public SignalRContext(DbContextOptions<SignalRContext> options) : base(options) { }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
