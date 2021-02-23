using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Melodie.Models
{
    public class Playlist
    {
        [Key, Column("playlist_id")]
        public int? PlaylistId { get; set; }
        
        
        [Required, Column("user_id")]
        public int? UserId { get; set; }
        
        
        [Required, Column("color_id")]
        public int? ColorId { get; set; }
        
        
        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }
        
        
        [DataType(DataType.MultilineText), Column("Description"), MaxLength(255)]
        public string Description { get; set; }
        
        
        public List<Music> Musics { get; set; }

        public Playlist()
        {
            UserId = 1;
            ColorId = 1;
            Name = "Nouvelle playlist";
            //Musics = new List<Music>();
        }
    }
}