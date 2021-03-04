﻿using System;
using System.Collections.Generic;
using System.IO;
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
            "wav", "ogg", "oga", "aif", "caf", "flac", "alac", "ac3", "mp3", "wma", "au", "asf", "aac"
        });

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
            // Get file path
            var filePath = Path.GetFileNameWithoutExtension(music.MusicFile.FileName);
            var fileExtension = Path.GetExtension(music.MusicFile.FileName);
            filePath = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + filePath.Trim() + fileExtension;
            
            // Check file extension
            if (!IsFileAMusic(fileExtension))
            {
                return RedirectToAction("Playlist", "Playlist", new { pid = music.PlaylistId });
            }

            // Get upload path
            // TODO: Doesn't work !
            // var uploadPath = ConfigurationManager.AppSettings["UserMusicPath"];
            //const string uploadPath = "D:\\MelodieStorage\\Musics\\";
            
            var relativePath = Path.Combine(UploadFolder, filePath);
            var absolutePath = Path.Combine(_env.WebRootPath, UploadFolder, filePath);

            music.FilePath = relativePath;
            
            // Set the creation date
            music.CreationDate = DateTime.Now;
            
            // Save the file onto the server
            if (music.MusicFile.Length > 0)
            {
                await using Stream fileStream = new FileStream(absolutePath, FileMode.Create);
                await music.MusicFile.CopyToAsync(fileStream);
            }
            
            // Save the music into the database
            await _dbService.AddMusic(music);

            return RedirectToAction("Playlist", "Playlist", new { pid = music.PlaylistId });
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
                ? RedirectToAction("Playlist", "Playlist", new { pid = playlistId })
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
    }
}