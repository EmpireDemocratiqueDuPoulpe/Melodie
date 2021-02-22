using System.ComponentModel.DataAnnotations;
using Melodie.Data;

namespace Melodie.Models
{
    public class Playlist
    {
        private MelodieDbContext _context;
        
        [Key] public int? playlist_id { get; set; }
        [Required] public int? user_id { get; set; }
        [Required] public int? color_id { get; set; }
        [Required] [MaxLength(100)] public string name { get; set; }
        [DataType(DataType.MultilineText)] [MaxLength(255)] public string description { get; set; }

        public Playlist()
        {
            user_id = 1;
            color_id = 1;
            name = "Nouvelle playlist";
        }
    }
}