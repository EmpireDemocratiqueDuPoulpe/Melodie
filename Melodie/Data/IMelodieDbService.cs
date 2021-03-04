using System.Collections.Generic;
using System.Threading.Tasks;
using Melodie.Models;

namespace Melodie.Data
{
    public interface IMelodieDbService
    {
        // GET
        Task<Playlist> GetPlaylistById(int playlistId);
        Task<IEnumerable<Playlist>> GetPlaylistsOf(string userId);
        
        Task<Music> GetMusicById(int musicId);
        Task<IEnumerable<Music>> GetMusicsOf(int playlistId);
        Task<IEnumerable<Music>> GetLastMusics(int count = 10);
        
        // ADD
        Task<int> AddPlaylist(Playlist playlist);
        Task<int> AddMusic(Music music);
        
        // UPDATE
        Task<int> UpdatePlaylist(Playlist playlist);
        Task<int> UpdateMusic(Music music);
        
        // DELETE
        Task<int> DeletePlaylist(Playlist playlist);
        Task<int> DeletePlaylistById(int playlistId);
        Task<int> DeleteMusic(Music music);
        Task<int> DeleteMusicById(int musicId);
    }
}