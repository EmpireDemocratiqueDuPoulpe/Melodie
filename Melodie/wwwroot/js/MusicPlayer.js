/* Const
-------------------------------------------------- */

let wavesurfer;
const waveformHeight = 54;
const defaultVolume = 0.5;

class Music {
    id = 0;
    uri = "";
    
    constructor(id, uri) {
        this.id = id;
        this.uri = uri;
    }
}

// TODO: Change the object for something with a constant order (Map, Array, ...)
const playlist = {};
let currentSong;

let playIcon;
let pauseIcon;
let volumeIcon;
let muteIcon;

let muteBtn;
let volumeSlider;
let currentVolume;

/* Wavesurfer and events
-------------------------------------------------- */

document.addEventListener('DOMContentLoaded', function(event) {
    
    /* Wavesurfer
    -------------------------------------------------- */
    const waveform = document.querySelector('#music-player-waveform');

    // Instance creation
    wavesurfer = WaveSurfer.create({
        container: waveform,
        backend: 'MediaElement',
        waveColor: '#8F3531',
        progressColor: '#F95950',
        cursorColor: getStyle(waveform, "backgroundColor"),
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
                    padding: '5px',
                    'background-color': '#000',
                    color: '#fff'
                }
            })
        ]
    });

    wavesurfer.setVolume(defaultVolume);

    /* Playlist creation
   -------------------------------------------------- */
    
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

    /* Events
    -------------------------------------------------- */
    // Wavesurfer events
    wavesurfer.on('ready', function () {
        wavesurfer.play();
    });

    wavesurfer.on('play', function () {
        updatePlayIcon();
    });

    wavesurfer.on('pause', function () {
        updatePlayIcon();
    });

    wavesurfer.on('finish', function () {
        playNextMusic();
    });

    // DOM events
    // Play / pause button event
    const playBtn = document.querySelector('#music-player-play-btn');
    playIcon = playBtn.querySelector('#play-icon');
    pauseIcon = playBtn.querySelector('#pause-icon');

    playBtn.addEventListener('click', playPause, false);

    // Previous button event
    const previousBtn = document.querySelector('#music-player-previous-btn');
    previousBtn.addEventListener('click', playPreviousMusic, false);

    // Next button event
    const nextBtn = document.querySelector('#music-player-next-btn');
    nextBtn.addEventListener('click', playNextMusic, false);

    // Mute button event
    muteBtn = document.querySelector('#music-player-mute-btn');
    volumeIcon = muteBtn.querySelector('#volume-icon');
    muteIcon = muteBtn.querySelector('#mute-icon');
    muteBtn.addEventListener('click', mute, false);

    // Volume slider event
    volumeSlider = document.querySelector('#music-player-volume-slider');
    volumeSlider.value = defaultVolume;

    volumeSlider.oninput = function () {
        wavesurfer.setVolume(Number(this.value));
        wavesurfer.setMute(false);
        updateMuteIcon();
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

function playNextMusic() {
    let nextMusic = playlist[Object.keys(playlist)[currentSong + 1]];

    if (nextMusic == null) {
        nextMusic = playlist[Object.keys(playlist)[0]];
    }

    playMusic(nextMusic);
}

function playPreviousMusic() {
    let previousMusic;
    
    if (currentSong - 1 === -1) {
        previousMusic = playlist[Object.keys(playlist)[Object.keys(playlist).length - 1]]
    } else {
        previousMusic = playlist[Object.keys(playlist)[currentSong - 1]];

        if (previousMusic == null) {
            previousMusic = playlist[Object.keys(playlist)[0]];
        }
    }
    
    playMusic(previousMusic);
}

function playPause() {
    wavesurfer.playPause();
}

function updatePlayIcon() {
    if (wavesurfer.isPlaying()) {
        playIcon.style.display = 'none';
        pauseIcon.style.display = 'block';
    } else {
        pauseIcon.style.display = 'none';
        playIcon.style.display = 'block';
    }
}

function updateMuteIcon() {
    if (wavesurfer.isMuted || volumeSlider.value === "0") {
        volumeIcon.style.display = 'none';
        muteIcon.style.display = 'block';
    } else {
        muteIcon.style.display = 'none';
        volumeIcon.style.display = 'block';
    }
}

function mute() {
    wavesurfer.toggleMute();
    
    if (wavesurfer.isMuted) {
        currentVolume = volumeSlider.value;
        volumeSlider.value = volumeSlider.min;
    } else {
        volumeSlider.value = currentVolume;
    }
    
    updateMuteIcon();
}