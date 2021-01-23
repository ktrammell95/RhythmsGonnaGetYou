using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class MusicContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Music");
        }
    }
}