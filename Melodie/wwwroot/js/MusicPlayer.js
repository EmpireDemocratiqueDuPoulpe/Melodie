/* Consts
-------------------------------------------------- */
const defaultVolume = 0.5;

/* Wavesurfer
-------------------------------------------------- */
// Instance creation
const wavesurfer = WaveSurfer.create({
    container: "#music-player-waveform",
    backend: "MediaElement",
    waveColor: '#D9DCFF',
    progressColor: '#4353FF',
    cursorColor: '#4353FF',
    barWidth: 3,
    barRadius: 3,
    cursorWidth: 1,
    height: 64,
    barGap: 3
});

// Events
wavesurfer.on("ready", function () {
    wavesurfer.setVolume(defaultVolume);
    wavesurfer.play();
});

/* Buttons
-------------------------------------------------- */

document.addEventListener("DOMContentLoaded", function(event) {
    // Play buttons event
    const playButtons = document.querySelectorAll(".song-play-btn");

    forEach(playButtons, function (index, button) {
        button.addEventListener("click", playMusic, false);
    });
    
    // Play / pause button event
    const playBtn = document.querySelector("#music-player-play-btn");
    playBtn.addEventListener("click", playPause, false);

    // Mute button event
    const muteBtn = document.querySelector("#music-player-mute-btn");
    muteBtn.addEventListener("click", mute, false);

    // Volume slider event
    const volumeSlider = document.querySelector("#music-player-volume-slider");
    volumeSlider.value = defaultVolume;
        
    volumeSlider.oninput = function () {
        wavesurfer.setVolume(Number(this.value));
    };

    // Volume slider event
    const zoomSlider = document.querySelector("#music-player-zoom-slider").oninput = function () {
        wavesurfer.zoom(Number(this.value));
    };
});

/* Functions
-------------------------------------------------- */

function playMusic(event) {
    const musicUri = event.target.dataset.url;
    wavesurfer.load("../" + musicUri);
}

function playPause() {
    wavesurfer.playPause();
}

function mute() {
    wavesurfer.toggleMute();
}