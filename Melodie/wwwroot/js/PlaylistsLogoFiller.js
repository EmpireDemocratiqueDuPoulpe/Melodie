/** Get playlists **/
const smallPlaylists = document.querySelectorAll(".playlist-block");
const fullPlaylist = document.querySelectorAll("#playlist-info");

let playlists;

if (smallPlaylists != null && fullPlaylist != null) {
    playlists = [...smallPlaylists, ...fullPlaylist];
} else {
    if (smallPlaylists == null) {
        playlists = fullPlaylist;
    } else {
        playlists = smallPlaylists;
    }
}

/** Set playlists logo text **/
forEach(playlists, function (index, playlist) {
   const logo = playlist.querySelector(".playlist-logo.auto-acronym");
   const title = playlist.querySelector(".playlist-title");
   let acronym;
   
   if (logo != null) {
       if (title.tagName.toLowerCase() === "input") {
           acronym = title.value;
       } else {
           acronym = title.textContent;
       }

       if (acronym != null) {
           acronym = acronym.match(/\b(\w)/g).join("").toUpperCase();

           logo.setAttribute("data-acronym", acronym);
       }
   }
});