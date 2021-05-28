using Microsoft.EntityFrameworkCore;
using BackEndCard.Models;

namespace BackEndCard.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Card> Cards {get; set;}
    }
}