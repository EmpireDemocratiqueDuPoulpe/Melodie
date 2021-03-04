using Melodie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Melodie.Data
{
    public class MelodieDbContext : IdentityDbContext
    {
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        
        public MelodieDbContext(DbContextOptions<MelodieDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}