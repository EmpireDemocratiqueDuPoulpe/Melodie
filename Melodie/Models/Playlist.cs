using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Melodie.Models
{
    public class Playlist
    {
        [Key, Column("playlist_id")]
        public int? PlaylistId { get; init; }
        
        
        [Required, Column("user_id")]
        public int? UserId { get; init; }
        
        
        [Required, Column("color_id")]
        public int? ColorId { get; set; }
        
        
        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }
        
        
        [DataType(DataType.MultilineText), Column("Description"), MaxLength(255)]
        public string Description { get; set; }
        
        
        public List<Music> Musics { get; set; }
        
        
        [NotMapped, Compare("Name", ErrorMessage = "The confirmation doesn't match the playlist name.")]
        public string DeleteConfirmation { get; set; }

        // TODO: Remove UserId after login system
        public Playlist()
        {
            UserId = 1;
            ColorId = 1;
            Name = "Nouvelle playlist";
        }
    }
}