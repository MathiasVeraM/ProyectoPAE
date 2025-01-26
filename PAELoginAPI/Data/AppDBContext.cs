using Microsoft.EntityFrameworkCore;
using PAELoginAPI.Models;

namespace PAELoginAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {            
        }
        public DbSet<User> users { get; set; }
    }
}
