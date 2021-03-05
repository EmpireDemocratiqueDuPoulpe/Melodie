using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Melodie.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
        //private readonly ILogger<MusicController> _logger;
        private readonly IMelodieDbService _dbService;
        private readonly IWebHostEnvironment _env;

        private readonly List<string> _audioFilesExt = new(new[]
        {
            "wav", "ogg", "oga", "caf", "flac", "m4a", "mp3", "wma", "au", "asf", "aac", "webm"
        });

        private readonly Dictionary<string, string> _contentTypesExt = new()
        {
            // .wav
            {"audio/x-wav", ".wav"},
            {"audio/vnd.wave", ".wav"},
            {"audio/wav", ".wav"},
            {"audio/wave", ".wav"},
            {"audio/x-pn-wav", ".wav"},
            // .ogg / .oga
            {"application/ogg", ".ogg"},
            {"audio/ogg", ".ogg"},
            // .caf
            {"audio/x-caf", ".caf"},
            // .flac
            {"audio/x-flac", ".flac"},
            {"audio/flac", ".flac"},
            // .m4a
            {"audio/mp4", ".m4a"},
            // .mp3
            {"audio/mpeg", ".mp3"},
            // .wma
            {"video/x-ms-wma", ".wma"},
            // .au
            {"audio/basic", ".au"},
            // .asf
            {"video/x-ms-asf", ".asf"},
            {"application/vnd.ms-asf", ".asf"},
            // .aac
            {"audio/aac", ".aac"},
            // .webm
            {"audio/webm", ".webm"},
        };
        
        private const string UploadFolder = "musics/";

        public MusicController(IMelodieDbService service, IWebHostEnvironment env)
        {
            _dbService = service;
            _env = env;
        }
        
        /* GET
        -------------------------------------------------- */
        public PartialViewResult AddMusic()
        {
            return PartialView("AddMusicFormPartial");
        }
        
        /* ADD
        -------------------------------------------------- */
        //Music/Add
        [HttpPost("Music/Add", Name = "AddMusic")]
        public async Task<ActionResult<Music>> Add(Music music)
        {
            Music uploadedMusic;
            
            // Get the music file
            if (music.MusicFile != null)
            {
                uploadedMusic = await AddByFile(music);
            }
            else if (music.ExternalLink != null)
            {
                uploadedMusic = await AddByLink(music);
            }
            else
            {
                return RedirectToAction(nameof(Playlist), "Playlist", new { pid = music.PlaylistId });
            }

            // Add the music to the playlist if the upload is successful
            if (uploadedMusic == null)
            {
                return RedirectToAction(nameof(Playlist), "Playlist", new { pid = music.PlaylistId });
            }

            // Save the music into the database
            await _dbService.AddMusic(uploadedMusic);

            return RedirectToAction(nameof(Playlist), "Playlist", new { pid = music.PlaylistId });
        }

        public async Task<Music> AddByFile(Music music)
        {
            // Get file path
            var filePath = Path.GetFileNameWithoutExtension(music.MusicFile.FileName);
            var fileExtension = Path.GetExtension(music.MusicFile.FileName);
            filePath = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + filePath.Trim() + fileExtension;
            
            // Check file extension
            if (!IsFileAMusic(fileExtension))
            {
                RedirectToAction(nameof(Playlist), "Playlist", new { pid = music.PlaylistId });
                return null;
            }
            
            // Get upload path
            // TODO: Doesn't work !
            // var uploadPath = ConfigurationManager.AppSettings["UserMusicPath"];
            //const string uploadPath = "D:\\MelodieStorage\\Musics\\";
            
            var relativePath = Path.Combine(UploadFolder, filePath);
            var absolutePath = Path.Combine(_env.WebRootPath, UploadFolder, filePath);

            music.FilePath = relativePath;

            // Save the file onto the server
            if (music.MusicFile.Length > 0)
            {
                await using (Stream fileStream = new FileStream(absolutePath, FileMode.Create))
                {
                    await music.MusicFile.CopyToAsync(fileStream);
                }
            }
            
            // Set the creation date
            music.CreationDate = DateTime.Now;
            
            // Set the file duration
            var tagFile = TagLib.File.Create(absolutePath);
            var duration = tagFile.Properties.Duration;

            music.Duration = duration.ToString(@"mm\:ss");

            return music;
        }
        
        public async Task<Music> AddByLink(Music music)
        {
            using (var httpClient = new HttpClient())
            {
                using (var result = await httpClient.GetAsync(music.ExternalLink))
                {
                    if (!result.IsSuccessStatusCode) return null;
                    
                    // Get file type
                    var contentType = result.Content.Headers.ContentType.MediaType;
                    var ext = GetExtensionForContentType(contentType);

                    if (ext == null) return null;
                        
                    // Get file name
                    var name = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + "_downloaded" + ext;
                        
                    // Get file paths
                    var relativePath = Path.Combine(UploadFolder, name);
                    var absolutePath = Path.Combine(_env.WebRootPath, UploadFolder, name);

                    music.FilePath = relativePath;

                    // Save the file onto the server
                    await using (Stream fileStream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await result.Content.CopyToAsync(fileStream);
                    }
                    
                    // Set the creation date
                    music.CreationDate = DateTime.Now;
                    
                    // Set the file duration
                    var tagFile = TagLib.File.Create(absolutePath);
                    var duration = tagFile.Properties.Duration;

                    music.Duration = duration.ToString(@"mm\:ss");
                        
                    return music;
                }
            }
        }

        /* DELETE
        -------------------------------------------------- */
        //Music/Delete
        [HttpPost("Music/Delete", Name = "DelMusic")]
        public async Task<ActionResult<Music>> Delete(Music music)
        {
            if (music.MusicId == null)
            {
                return BadRequest("ID must be set for DELETE query.");
            }

            var playlistId = music.PlaylistId;
            var result = await _dbService.DeleteMusic(music);
            return (result > 0)
                ? RedirectToAction(nameof(Playlist), "Playlist", new { pid = playlistId })
                : NotFound();
        }
        
        //Music/DeleteById
        [HttpPost("Music/DeleteById", Name = "DelMusicById")]
        public async Task<ActionResult<Music>> DeleteById(int mid)
        {
            var result = await _dbService.DeleteMusicById(mid);
            return (result > 0) ? NoContent() : NotFound();
        }
        
        /* OTHER
        -------------------------------------------------- */
        public bool IsFileAMusic(string ext)
        {
            return _audioFilesExt.Contains(ext.Replace(".", string.Empty).ToLower());
        }

        public string GetExtensionForContentType(string contentType)
        {
            return _contentTypesExt.ContainsKey(contentType) ? _contentTypesExt[contentType] : null;
        }
    }
}