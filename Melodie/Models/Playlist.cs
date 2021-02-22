using System.ComponentModel.DataAnnotations;
using Melodie.Data;

namespace Melodie.Models
{
    public class Playlist
    {
        private MelodieDbContext _context;
        
        [Key]
        public int? playlist_id { get; set; }
        public int? user_id { get; set; }
        public int? color_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}