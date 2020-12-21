using System.Data.Entity;
using DashboardApp.Models;

namespace DashboardApp.Data
{
    public class WebStoreDbContext : DbContext
    {
        public WebStoreDbContext(): base("name = WebStore") {}
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Collection)
                .WillCascadeOnDelete(false);
        }
    }
    
}