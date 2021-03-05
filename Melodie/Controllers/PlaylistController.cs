using System;
using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Melodie.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly IMelodieDbService _dbService;

        public PlaylistController(IMelodieDbService service)
        {
            _dbService = service;
        }
        
        /* GET
        -------------------------------------------------- */
        //Playlist/ID
        [HttpGet("Playlist/{pid:int}", Name = "GetByPlaylistId")]
        public async Task<IActionResult> Playlist(int pid)
        {
            var playlist = await _dbService.GetPlaylistById(pid);

            if (playlist == default) return RedirectToAction(nameof(Index), "Home");
            
            ViewBag.Title = playlist.Name;

            return View(playlist);
        }

        /* ADD
        -------------------------------------------------- */
        //Playlist/Add
        [HttpPost("Playlist/Add", Name = "AddPlaylist")]
        public async Task<ActionResult<Playlist>> Add()
        {
            var playlist = new Playlist {UserId = User.Identity.GetUserId()};

            var playlistId = await _dbService.AddPlaylist(playlist);
            return RedirectToAction(nameof(Playlist), "Playlist", new { pid = playlistId });
        }
        
        /* UPDATE
        -------------------------------------------------- */
        //Playlist/Update
        [HttpPost("Playlist/Update", Name = "UpdatePlaylist")]
        public async Task<ActionResult<Playlist>> Update(Playlist playlist)
        {
            if (playlist.PlaylistId == null)
            {
                return BadRequest("ID must be set for UPDATE query.");
            }

            var result = await _dbService.UpdatePlaylist(playlist);
            
            // Fix a b.u.g where the modal confirmation message wasn't updated with the name.
            // Possibles fixes:
            // 1 - Reload the page on update (current)
            // 2 - Use Ajax.BeginForm
            //return (result > 0) ? NoContent() : NotFound();
            return (result > 0)
                ? RedirectToAction(nameof(Playlist), "Playlist", new {pid = playlist.PlaylistId})
                : NotFound();
        }
        
        /* DELETE
        -------------------------------------------------- */
        //Playlist/Delete
        [HttpPost("Playlist/Delete", Name = "DelPlaylist")]
        public async Task<ActionResult<Playlist>> Delete(Playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.OpenDeleteModal = true;
                return View("Playlist", playlist);
            }
            
            if (playlist.PlaylistId == null)
            {
                return BadRequest("ID must be set for DELETE query.");
            }

            if (playlist.Name != playlist.DeleteConfirmation)
            {
                return BadRequest("The confirmation doesn't match the playlist name.");
            }
            
            var result = await _dbService.DeletePlaylist(playlist);
            return (result > 0) ? RedirectToAction(nameof(Index), "Home") : NotFound();
        }
        
        //Playlist/DeleteById
        [HttpPost("Playlist/DeleteById", Name = "DelPlaylistById")]
        public async Task<ActionResult<Playlist>> DeleteById(int pid)
        {
            var result = await _dbService.DeletePlaylistById(pid);
            return (result > 0) ? RedirectToAction(nameof(Index), "Home") : NotFound();
        }
    }
}