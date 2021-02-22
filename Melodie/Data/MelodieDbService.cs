using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Melodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Melodie.Data
{
    public class MelodieDbService : IMelodieDbService
    {
        private readonly MelodieDbContext _db;

        public MelodieDbService(MelodieDbContext dbContext)
        {
            _db = dbContext;
        }
        
        // GET
        public async Task<User> GetUserById(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }
        
        public async Task<Playlist> GetPlaylistById(int playlistId)
        {
            return await _db.Playlists.FirstOrDefaultAsync(p => p.playlist_id == playlistId);
        }
        
        public async Task<IEnumerable<Playlist>> GetPlaylistsOf(int userId)
        {
            return await _db.Playlists
                .Where(p => p.user_id == userId)
                .OrderByDescending(p => p.playlist_id)
                .ToListAsync();
        }

        // ADD
        public async Task<int> AddUser(User user)
        {
            _db.Add(user);
            return await _db.SaveChangesAsync();
        }
        
        public async Task<int> AddPlaylist(Playlist playlist)
        {
            _db.Add(playlist);
            await _db.SaveChangesAsync();
            //return await _db.SaveChangesAsync();

            return playlist.playlist_id ?? -1;
        }

        // UPDATE
        public async Task<int> UpdateUser(User user)
        {
            try
            {
                _db.Users.Update(user);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
        
        public async Task<int> UpdatePlaylist(Playlist playlist)
        {
            try
            {
                _db.Playlists.Update(playlist);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        // DELETE
        public async Task<int> DeleteUser(int userId)
        {
            try
            {
                _db.Users.Remove(new User {UserId = userId});
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
        
        public async Task<int> DeletePlaylist(int playlistId)
        {
            try
            {
                _db.Playlists.Remove(new Playlist {playlist_id = playlistId});
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}