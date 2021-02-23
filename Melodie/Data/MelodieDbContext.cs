using Melodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Melodie.Data
{
    public class MelodieDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public MelodieDbContext(DbContextOptions<MelodieDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Music>()
            //    .HasOne(m => m.Playlist)
            //    .WithMany(p => p.Musics)
            //    .HasForeignKey(m => m.PlaylistId);
        }
    }
}