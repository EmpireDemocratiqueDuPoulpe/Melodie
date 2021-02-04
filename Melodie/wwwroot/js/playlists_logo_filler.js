/** Custom foreach **/
const forEach = function (array, callback, scope) {
    for (let i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]);
    }
}

/** Set playlists logo text **/
const playlists = document.querySelectorAll(".playlist-block");

forEach(playlists, function (index, playlist) {
   const logo = playlist.querySelector(".playlist-logo");
   const title = playlist.querySelector(".playlist-title");
   
   const acronym = title.textContent.match(/\b(\w)/g).join("").toUpperCase();
   
   logo.setAttribute("data-acronym", acronym);
});