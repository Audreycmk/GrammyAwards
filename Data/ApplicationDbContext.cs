using GrammyAwards.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GrammyAwards.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> // Inherit from IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Award> Awards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method to apply identity model

            // Configure relationships for your custom tables
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<Award>()
                .HasOne(a => a.Song)
                .WithMany(s => s.Awards)
                .HasForeignKey(a => a.SongId);
        }
    }
}
