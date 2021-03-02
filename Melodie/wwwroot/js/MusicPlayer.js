/* Const
-------------------------------------------------- */

// Wavesurfer parameters
let wavesurfer;
const waveformHeight = 54;
const defaultVolume = 0.5;

// Musics & playlist
class Music {
    id = 0;
    uri = '';
    
    constructor(id, uri) {
        this.id = id;
        this.uri = uri;
    }
}

// TODO: Change the object for something with a constant order (Map, Array, ...)
const playlist = {};
let currentSong = -1;
let playFirstSong = false;

// Global play
let globalPlayBtn;

// Volume
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
        cursorColor: getStyle(waveform, 'backgroundColor'),
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
        const playBtn = music.querySelector('.song-play-btn');

        if (playBtn != null) {
            // Get data
            const data = getPlayBtnData(playBtn);

            // Add a music to the playlist object
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
    globalPlayBtn = document.querySelector('#music-player-play-btn');

    globalPlayBtn.addEventListener('click', playPause, false);

    // Previous button event
    const previousBtn = document.querySelector('#music-player-previous-btn');
    previousBtn.addEventListener('click', playPreviousMusic, false);

    // Next button event
    const nextBtn = document.querySelector('#music-player-next-btn');
    nextBtn.addEventListener('click', playNextMusic, false);

    // Mute button event
    muteBtn = document.querySelector('#music-player-mute-btn');
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

// Get the id and the uri of the music (stored into the play button)
function getPlayBtnData(playBtn) {
    const id = playBtn.dataset.id;
    const uri = playBtn.dataset.uri;
    return {id: Number(id), uri: uri};
}

// Function called every time a play button of a music is pressed
function playOnEvent(event) {
    const data = getPlayBtnData(event.target);

    // Check if the button pressed is the current music
    let currentMusic = document.querySelector('.song-row .song-play-btn[data-id="'+data.id+'"].playing');
    
    // If yes: pause
    if (currentMusic != null) {
        wavesurfer.pause();
        setPlayRowAsPlaying(currentMusic, false);
    } else {
        // Check if the clicked button is the same music as the one actually paused
        // If yes: unpause the song
        if (data.id === currentSong && wavesurfer.getCurrentTime() > 0) {
            wavesurfer.play();

            let currentMusic = document.querySelector('.song-row .song-play-btn[data-id="' + currentSong + '"]');
            setPlayRowAsPlaying(currentMusic, true);
        } else {
            playMusic(new Music(data.id, data.uri))
        }
    }
}

// Main function called for playing a music no matter what button is pressed or event triggered
function playMusic(music) {
    // Set previous music as not playing
    if (currentSong >= 0) {
        updatePlayPauseIcon('.song-row .song-play-btn[data-id="'+currentSong+'"]', false);
    }
    
    // Play the music
    playFirstSong = true;
    currentSong = Number(music.id);
    wavesurfer.load('../' + music.uri);
    
    // Set the current music as playing
    updatePlayPauseIcon('.song-row .song-play-btn[data-id="'+music.id+'"]', true);
}

// Play the next music
function playNextMusic() {
    let nextMusic = playlist[Object.keys(playlist)[currentSong + 1]];

    if (nextMusic == null) {
        nextMusic = playlist[Object.keys(playlist)[0]];
    }

    playMusic(nextMusic);
}

// Play the previous music
function playPreviousMusic() {
    let previousMusic;
    
    // Play the last song of the playlist if the current song is the first one
    if (currentSong - 1 === -1) {
        previousMusic = playlist[Object.keys(playlist)[Object.keys(playlist).length - 1]]
    // Else play the previous song
    } else {
        previousMusic = playlist[Object.keys(playlist)[currentSong - 1]];

        if (previousMusic == null) {
            previousMusic = playlist[Object.keys(playlist)[0]];
        }
    }
    
    playMusic(previousMusic);
}

// Function called when the global Play/Pause button is pressed
function playPause() {
    if (!playFirstSong) {
        playMusic(playlist[Object.keys(playlist)[0]]);
    }

    wavesurfer.playPause();

    updatePlayPauseIcon('.song-row .song-play-btn[data-id="' + currentSong + '"]', wavesurfer.isPlaying());
}

// Update the music play button icon
function updatePlayPauseIcon(selector, playing) {
    const playBtn = document.querySelector(selector);
    
    if (playBtn != null) {
        setPlayRowAsPlaying(playBtn, playing);
    }
}

// Set a play button and its parent .playing
function setPlayRowAsPlaying(playBtn, playing) {
    playBtn.setAttribute('class', 'song-play-btn' + (playing ? ' playing' : ''));
    playBtn.parentElement.parentElement.setAttribute('class', 'song-row' + (playing ? ' playing' : ''));
}

// Update the global Play/Pause button icon
function updatePlayIcon() {
    globalPlayBtn.setAttribute('class', 'music-player-btn bigger no-select' + (wavesurfer.isPlaying() ? ' playing' : ''));
}

// Update the mute button icon
function updateMuteIcon() {
    muteBtn.setAttribute('class', 'slider-icon clickable-icon' + (wavesurfer.isMuted || volumeSlider.value === '0' ? ' muted' : ''));
}

// Function called when the mute button is pressed
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