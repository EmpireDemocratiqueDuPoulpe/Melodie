using Melodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Melodie.Data
{
    public class MelodieDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public MelodieDbContext(DbContextOptions<MelodieDbContext> options) : base(options) {}
    }
}