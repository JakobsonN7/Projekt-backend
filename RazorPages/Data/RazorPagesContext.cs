using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Data
{
    public class RazorPagesContext : DbContext
    {
        public RazorPagesContext(DbContextOptions<RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPages.Models.User> Users { get; set; } 
    }
}
