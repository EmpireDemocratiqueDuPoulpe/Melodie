using System.Collections.Generic;
using System.Threading.Tasks;
using Melodie.Controllers;
using Melodie.Data;
using Melodie.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Melodie.UnitTests
{
    public class PlaylistControllerTests
    {
        private DbContextOptions<MelodieDbContext> _dbContextOptions = new DbContextOptionsBuilder<MelodieDbContext>()
            .UseInMemoryDatabase(databaseName: "melodie_db")
            .Options;

        private PlaylistController _playlistController;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();

            _playlistController = new PlaylistController(
                new MelodieDbService(
                    new MelodieDbContext(_dbContextOptions)
                    )
                );
        }

        private void SeedDb()
        {
            using var dbContext = new MelodieDbContext(_dbContextOptions);
            
            var Playlists = new List<Playlist>
            {
                new Playlist {PlaylistId = 1, UserId = "1", Name = "Playlist 1"},
                new Playlist {PlaylistId = 2, UserId = "1", Name = "Playlist 2"},
                new Playlist {PlaylistId = 3, UserId = "2", Name = "Playlist 3"}
            };

            var Musics = new List<Music>
            {
                new Music {MusicId = 1, PlaylistId = 1, Name = "Music 1", FilePath = "music1.mp3"},
                new Music {MusicId = 2, PlaylistId = 1, Name = "Music 2", FilePath = "music2.mp3"},
                new Music {MusicId = 3, PlaylistId = 2, Name = "Music 1", FilePath = "music1.mp3"},
                new Music {MusicId = 4, PlaylistId = 2, Name = "Music 2", FilePath = "music2.ogg"},
                new Music {MusicId = 5, PlaylistId = 3, Name = "Music 1", FilePath = "music1.mp3"},
                new Music {MusicId = 6, PlaylistId = 3, Name = "Music 2", FilePath = "music2.mp3"}
            };

            var AspNetUsers = new List<AspNetUser>
            {
                new AspNetUser {Id = "1", UserName = "User 1"},
                new AspNetUser {Id = "2", UserName = "User 2"}
            };
            
            dbContext.AddRange(Playlists);
            dbContext.AddRange(Musics);
            dbContext.AddRange(AspNetUsers);

            dbContext.SaveChanges();
        }

        [Test]
        public async Task GetAllPlaylistsOfUser()
        {
            //await using (var dbContext = new MelodieDbContext(_dbContextOptions))
            //{
            //    var playlists = (await _playlistController.Playlist())
            //}
        }
    }
}