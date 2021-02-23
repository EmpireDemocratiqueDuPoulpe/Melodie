using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Melodie.Models
{
    public class Music
    {
        [Key, Column("music_id")]
        public int? MusicId { get; set; }
        
        
        [Required, Column("playlist_id")]
        public int? PlaylistId { get; set; }
        //[ForeignKey("playlist_id")]
        //public virtual Playlist Playlist { get; set; }
        public Playlist Playlist { get; set; }
        
        
        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }
        
        
        [Required, Column("file_path"), MaxLength(2048)]
        public string FilePath { get; set; }
        
        
        [NotMapped]
        public IFormFile MusicFile { get; set; }  
    }
}