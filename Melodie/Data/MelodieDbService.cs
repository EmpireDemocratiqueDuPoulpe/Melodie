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
        // Playlists
        public async Task<Playlist> GetPlaylistById(int playlistId)
        {
            return await _db.Playlists
                .Include(p => p.Musics)
                .FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
        }
        
        public async Task<IEnumerable<Playlist>> GetPlaylistsOf(string userId)
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

        public async Task<IEnumerable<Music>> GetLastMusics(int count = 10)
        {
            return await _db.Musics
                .OrderByDescending(m => m.MusicId)
                .Take(count)
                .ToListAsync();
        }

        /* ADD
        -------------------------------------------------- */
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