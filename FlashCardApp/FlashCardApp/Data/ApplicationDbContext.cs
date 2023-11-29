using FlashCardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }
    }
}
