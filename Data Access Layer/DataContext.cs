using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Access_Layer
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>()
            //.HasOne<ApplicationUser>(s => s.User)
            //.WithMany(g => g.Categories)
            //.HasForeignKey(s => s.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.Categories)
                .WithOne(t => t.User).HasForeignKey(p => p.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.Shelters)
                .WithOne(t => t.User).HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Shelter>()
            .HasOne<Category>(s => s.Category)
            .WithMany(g => g.Shelters)
            .HasForeignKey(s => s.CategoryId);

        }

    }
}