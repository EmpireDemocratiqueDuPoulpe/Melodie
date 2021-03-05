let addMusicOptions;
let optChanger;

const options = ['upload-by-file', 'upload-by-link'];
let currentOption = 0;

document.addEventListener('DOMContentLoaded', function() {
    addMusicOptions = document.querySelector('#add-music-options');
    optChanger = document.querySelector('#add-music-opt-changer');
    
    optChanger.addEventListener('click', changeToNextOption);
});

function changeToNextOption() {
    // Remove the previous class
    delClass(addMusicOptions, options[currentOption]);
    
    // Get the next option
    currentOption++;
    if (currentOption > options.length - 1) currentOption = 0;
    
    // Add the new class
    addClass(addMusicOptions, options[currentOption]);
}