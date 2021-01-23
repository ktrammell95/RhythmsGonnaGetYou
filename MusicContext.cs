using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class MusicContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Music");
        }
    }
}