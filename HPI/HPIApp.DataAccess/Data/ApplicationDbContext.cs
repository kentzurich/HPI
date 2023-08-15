using HPIApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HPIApp.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Logo> Logo { get; set; }
        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<HeroSection> HeroSection { get; set; }
        public DbSet<WhyUsSection> WhyUsSection { get; set; }
        public DbSet<AboutUsSection> AboutUsSection { get; set; }
        public DbSet<EventsSection> EventsSection { get; set; }
        public DbSet<FAQSection> FAQSection { get; set; }
        public DbSet<TestimonialSection> TestimonialSection { get; set; }
        public DbSet<GallerySection> GallerySection { get; set; }
        public DbSet<ContactSection> ContactSection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
