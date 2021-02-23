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
        
        /* GET
        -------------------------------------------------- */
        // Users
        public async Task<User> GetUserById(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }
        
        // Playlists
        public async Task<Playlist> GetPlaylistById(int playlistId)
        {
            return await _db.Playlists
                .Include(p => p.Musics)
                .FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
        }
        
        public async Task<IEnumerable<Playlist>> GetPlaylistsOf(int userId)
        {
            return await _db.Playlists
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.PlaylistId)
                .ToListAsync();
        }

        // Musics
        public async Task<Music> GetMusicById(int musicId)
        {
            return await _db.Musics.FirstOrDefaultAsync(m => m.MusicId == musicId);
        }

        public async Task<IEnumerable<Music>> GetMusicsOf(int playlistId)
        {
            return await _db.Musics
                .Where(m => m.MusicId == playlistId)
                .OrderBy(m => m.MusicId)
                .ToListAsync();
        }
        
        /* ADD
        -------------------------------------------------- */
        // Users
        public async Task<int> AddUser(User user)
        {
            _db.Add(user);
            return await _db.SaveChangesAsync();
        }
        
        // Playlists
        public async Task<int> AddPlaylist(Playlist playlist)
        {
            _db.Add(playlist);
            await _db.SaveChangesAsync();

            return playlist.PlaylistId ?? -1;
        }

        // Musics
        public async Task<int> AddMusic(Music music)
        {
            _db.Add(music);
            await _db.SaveChangesAsync();

            return music.MusicId ?? -1;
        }

        /* UPDATE
        -------------------------------------------------- */
        // Users
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
        
        // Playlists
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

        // Musics
        public async Task<int> UpdateMusic(Music music)
        {
            try
            {
                _db.Musics.Update(music);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
        
        /* DELETE
        -------------------------------------------------- */
        // Users
        public async Task<int> DeleteUser(int userId)
        {
            try
            {
                _db.Users.Remove(new User { UserId = userId });
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
        
        // Playlists
        public async Task<int> DeletePlaylist(Playlist playlist)
        {
            try
            {
                _db.Playlists.Remove(new Playlist { PlaylistId = playlist.PlaylistId });
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
        
        public async Task<int> DeletePlaylistById(int playlistId)
        {
            try
            {
                _db.Playlists.Remove(new Playlist { PlaylistId = playlistId });
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        // Musics
        public async Task<int> DeleteMusic(Music music)
        {
            try
            {
                _db.Musics.Remove(new Music { MusicId = music.MusicId });
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<int> DeleteMusicById(int musicId)
        {
            try
            {
                _db.Musics.Remove(new Music { MusicId = musicId });
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}