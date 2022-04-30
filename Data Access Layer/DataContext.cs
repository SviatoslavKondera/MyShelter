using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Access_Layer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<Category> Category { get; set; }
       
    }
}