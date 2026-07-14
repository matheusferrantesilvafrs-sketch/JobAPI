using JobAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<PostDados> PostDados {get; set;}  
    }
}