/* Const
-------------------------------------------------- */
const waveformHeight = 64;
const defaultVolume = 0.5;

class Music {
    id = 0;
    uri = "";
    
    constructor(id, uri) {
        this.id = id;
        this.uri = uri;
    }
}

const playlist = {};
let currentSong;

/* Wavesurfer
-------------------------------------------------- */
// Instance creation
const wavesurfer = WaveSurfer.create({
    container: '#music-player-waveform',
    backend: 'MediaElement',
    waveColor: '#D9DCFF',
    progressColor: '#4353FF',
    cursorColor: '#AAAAAA',
    barWidth: 3,
    barRadius: 3,
    cursorWidth: 1,
    barGap: 3,
    normalize: true,
    height: waveformHeight,
    hideScrollbar: true,
    responsive: true,
    plugins: [
        WaveSurfer.cursor.create({
            opacity: 1,
            showTime: true,
            customShowTimeStyle: {
                'font-size': '10px',
                padding: '2px',
                'background-color': '#000',
                color: '#fff'
            }
        })
    ]
});

wavesurfer.setVolume(defaultVolume);

// Events
wavesurfer.on('ready', function () {
    wavesurfer.play();
});

wavesurfer.on('mute', function (isMuted) {
});

wavesurfer.on('play', function () {
});

wavesurfer.on('pause', function () {
});

wavesurfer.on('finish', function () {
    let nextMusic = playlist[Object.keys(playlist)[currentSong + 1]];

    if (nextMusic == null) {
        nextMusic = playlist[Object.keys(playlist)[0]];
    }

    playMusic(nextMusic);
});

/* Buttons
-------------------------------------------------- */

document.addEventListener('DOMContentLoaded', function(event) {
    // Playlist creation
    const musics = document.querySelectorAll('.song-row');
    
    forEach(musics, function (index, music) {
        const playBtn = music.querySelector(".song-play-btn");
        
        if (playBtn != null) {
            const data = getPlayBtnData(playBtn);

            if (data.id !== undefined && data.uri !== undefined) {
                playlist[data.id] = new Music(data.id, data.uri);

                playBtn.addEventListener('click', playOnEvent, false);
            }
        }
    });
    
    // Play / pause button event
    const playBtn = document.querySelector('#music-player-play-btn');
    playBtn.addEventListener('click', playPause, false);

    // Mute button event
    const muteBtn = document.querySelector('#music-player-mute-btn');
    muteBtn.addEventListener('click', mute, false);

    // Volume slider event
    const volumeSlider = document.querySelector('#music-player-volume-slider');
    volumeSlider.value = defaultVolume;
        
    volumeSlider.oninput = function () {
        wavesurfer.setVolume(Number(this.value));
    };

    // Zoom slider event
    const zoomSlider = document.querySelector('#music-player-zoom-slider').oninput = function () {
        wavesurfer.zoom(Number(this.value));
    };
});

/* Functions
-------------------------------------------------- */

function getPlayBtnData(playBtn) {
    const id = playBtn.dataset.id;
    const uri = playBtn.dataset.uri;
    return {id: Number(id), uri: uri};
}

function playOnEvent(event) {
    const data = getPlayBtnData(event.target);

    playMusic(new Music(data.id, data.uri))
}

function playMusic(music) {
    currentSong = Number(music.id);
    wavesurfer.load('../' + music.uri);
}

function playPause() {
    wavesurfer.playPause();
}

function mute() {
    wavesurfer.toggleMute();
}