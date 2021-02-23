using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Melodie.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ILogger<PlaylistController> _logger;
        private readonly IMelodieDbService _dbService;

        public PlaylistController(ILogger<PlaylistController> logger, IMelodieDbService service)
        {
            _logger = logger;
            _dbService = service;
        }
        
        /* GET
        -------------------------------------------------- */
        //Playlist/ID
        [HttpGet("Playlist/{pid:int}", Name = "GetByPlaylistId")]
        public async Task<IActionResult> Playlist(int pid)
        {
            var playlist = await _dbService.GetPlaylistById(pid);

            if (playlist == default) return RedirectToAction("Index", "Home");
            
            ViewBag.Title = "Playlist - " + playlist.Name;

            return View(playlist);
        }
        
        /* ADD
        -------------------------------------------------- */
        //Playlist/Add
        [HttpPost("Playlist/Add", Name = "AddPlaylist")]
        public async Task<ActionResult<Playlist>> Add()
        {
            var playlist = new Playlist();

            var playlistId = await _dbService.AddPlaylist(playlist);
            return (playlist != default)
                ? RedirectToAction("Playlist", new { pid = playlistId })
                : BadRequest();
        }
        
        /* UPDATE
        -------------------------------------------------- */
        //Playlist/Update
        //[HttpPut("Playlist/Update", Name = "UpdatePlaylist")]
        [HttpPost("Playlist/Update", Name = "UpdatePlaylist")]
        public async Task<ActionResult<Playlist>> Update(Playlist playlist)
        {
            if (playlist.PlaylistId == null)
            {
                return BadRequest("ID must be set for UPDATE query.");
            }

            var result = await _dbService.UpdatePlaylist(playlist);
            return (result > 0) ? NoContent() : NotFound();
        }
        
        /* DELETE
        -------------------------------------------------- */
        //Playlist/Delete
        //[HttpDelete("Home/Playlist/Delete/{pid}", Name = "DelPlaylist")]
        [HttpPost("Playlist/Delete", Name = "DelPlaylist")]
        public async Task<ActionResult<Playlist>> Delete(Playlist playlist)
        {
            if (playlist.PlaylistId == null)
            {
                return BadRequest("ID must be set for DELETE query.");
            }
            
            var result = await _dbService.DeletePlaylist(playlist);
            return (result > 0) ? RedirectToAction("Index", "Home") : NotFound();
        }
        
        //Playlist/DeleteById
        [HttpPost("Playlist/DeleteById", Name = "DelPlaylistById")]
        public async Task<ActionResult<Playlist>> DeleteById(int pid)
        {
            var result = await _dbService.DeletePlaylistById(pid);
            return (result > 0) ? RedirectToAction("Index", "Home") : NotFound();
        }
    }
}