using Microsoft.EntityFrameworkCore;
using RestaurantApp.EntityLayer.Entities;
using System.Reflection;

namespace RestaurantApp.DataAccessLayer.Concretes
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PB89LUO; Database=RestaurantApp; Trusted_Connection=True;TrustServerCertificate=True");
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

       
    }
}
