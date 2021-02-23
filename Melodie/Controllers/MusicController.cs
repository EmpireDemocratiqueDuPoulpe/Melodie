using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Melodie.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<MusicController> _logger;
        private readonly IMelodieDbService _dbService;

        public MusicController(ILogger<MusicController> logger, IMelodieDbService service)
        {
            _logger = logger;
            _dbService = service;
        }
        
        /* GET
        -------------------------------------------------- */
        public PartialViewResult AddMusic()
        {
            return PartialView("AddMusicFormPartial");
        }
        
        /* ADD */
        //Home/AddMusic
        [HttpPost("Home/AddMusic", Name = "AddMusic")]
        public async Task<ActionResult<Music>> Add(Music music)
        {
            // Get file path
            var filePath = Path.GetFileNameWithoutExtension(music.MusicFile.FileName);
            var fileExtension = Path.GetExtension(music.MusicFile.FileName);
            filePath = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + filePath.Trim() + fileExtension;

            // Get upload path
            // TODO: Doesn't work !
            // var uploadPath = ConfigurationManager.AppSettings["UserMusicPath"];
            const string uploadPath = "D:\\MelodieStorage\\Musics\\";

            music.FilePath = uploadPath + filePath;
            
            // Save the file onto the server
            if (music.MusicFile.Length > 0)
            {
                await using Stream fileStream = new FileStream(music.FilePath, FileMode.Create);
                await music.MusicFile.CopyToAsync(fileStream);
            }
            
            // Save the music into the database
            var musicId = await _dbService.AddMusic(music);

            return (music != default)
                ? RedirectToAction("Playlist", "Playlist", new { pid = music.PlaylistId })
                : BadRequest();
        }
    }
}