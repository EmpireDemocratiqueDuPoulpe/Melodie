using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Melodie.Views.Home
{
    public class PlaylistModel : PageModel
    {
        //private readonly IMelodieDbService _melodieDbService;
        //
        //[FromRoute] public int? Pid { get; set; }
        //[BindProperty] public Playlist Playlist { get; set; }
//
        //public PlaylistModel(IMelodieDbService melodieDbService)
        //{
        //    _melodieDbService = melodieDbService;
        //}
        
        /****** GET / POST ******/
        //public async Task OnGetAsync()
        //{
        //    Playlist = await _melodieDbService.GetPlaylistById(Pid.GetValueOrDefault()) ?? new Playlist();
        //}
//
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
//
        //    var newPlaylist = false;
        //    var playlist = await _melodieDbService.GetPlaylistById(Pid.GetValueOrDefault());
//
        //    if (playlist == null)
        //    {
        //        newPlaylist = true;
        //        playlist = new Playlist();
        //    }
        //    
        //    playlist.playlist_id = Playlist.playlist_id;
        //    playlist.user_id = Playlist.user_id;
        //    playlist.color_id = Playlist.color_id;
        //    playlist.name = Playlist.name;
        //    playlist.description = Playlist.description;
//
        //    await (newPlaylist ? _melodieDbService.AddPlaylist(playlist) : _melodieDbService.UpdatePlaylist(playlist));
        //    return RedirectToPage("/Playlist", new {pid = playlist.playlist_id});
        //}
        //
        //public async Task<IActionResult> OnPostDelete()
        //{
        //    if (Pid != null) await _melodieDbService.DeletePlaylist(Pid.Value);
        //    return RedirectToPage("/Index");
        //}
    }//
}