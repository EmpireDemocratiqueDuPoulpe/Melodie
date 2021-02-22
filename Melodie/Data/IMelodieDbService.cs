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

        Task<Playlist> GetPlaylistById(int playlistId);
        Task<IEnumerable<Playlist>> GetPlaylistsOf(int userId);
        
        // ADD
        Task<int> AddUser(User user);
        Task<int> AddPlaylist(Playlist playlist);
        
        // UPDATE
        Task<int> UpdateUser(User user);
        Task<int> UpdatePlaylist(Playlist playlist);
        
        // DELETE
        Task<int> DeleteUser(int userId);
        Task<int> DeletePlaylist(Playlist playlist);
        Task<int> DeletePlaylistById(int playlistId);
    }
}