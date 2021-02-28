using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Melodie.Models;

namespace Melodie.Data
{
    public interface IMelodieDbService
    {
        // GET
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<int?> GetUserId(string username);
        Task<string?> SearchForUsername(string username);
        Task<string?> SearchForEmail(string email);
        Task<bool> IsUserPassword(int userId, string password);

        Task<Playlist> GetPlaylistById(int playlistId);
        Task<IEnumerable<Playlist>> GetPlaylistsOf(int userId);
        
        Task<Music> GetMusicById(int musicId);
        Task<IEnumerable<Music>> GetMusicsOf(int playlistId);
        Task<IEnumerable<Music>> GetLastMusics(int count = 10);
        
        // ADD
        Task<int> AddUser(User user);
        Task<int> AddPlaylist(Playlist playlist);
        Task<int> AddMusic(Music music);
        
        // UPDATE
        Task<int> UpdateUser(User user);
        Task<int> UpdatePlaylist(Playlist playlist);
        Task<int> UpdateMusic(Music music);
        
        // DELETE
        Task<int> DeleteUser(int userId);
        Task<int> DeletePlaylist(Playlist playlist);
        Task<int> DeletePlaylistById(int playlistId);
        Task<int> DeleteMusic(Music music);
        Task<int> DeleteMusicById(int musicId);
    }
}