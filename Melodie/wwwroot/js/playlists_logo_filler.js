/** Custom foreach **/
const forEach = function (array, callback, scope) {
    for (let i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]);
    }
}

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
   const logo = playlist.querySelector(".playlist-logo");
   const title = playlist.querySelector(".playlist-title");
   let acronym;
   
   if (title.tagName.toLowerCase() === "p") {
       acronym = title.textContent;
   } else {
       acronym = title.value;
   }
   
   if (acronym != null) {
       acronym = acronym.match(/\b(\w)/g).join("").toUpperCase();

       logo.setAttribute("data-acronym", acronym);
   }
});