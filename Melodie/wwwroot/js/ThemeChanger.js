/*
	Not used anymore.
	Switched to a solution using ASP.NET Cookies to prevent screen blinking on page load
*/

/* Const
-------------------------------------------------- */

let root;
let themeChanger;

const themeKeyName = 'melodie-theme';
const darkTheme = 'dark-theme';
const lightTheme = 'light-theme';

/* Set theme and add event
-------------------------------------------------- */

document.addEventListener('DOMContentLoaded', function(event) {
    // Set the theme
    root = document.getElementsByTagName('html')[0];
    setThemeOnStartup();
    
    // Add click event
    themeChanger = document.querySelector('#theme-selector');
    themeChanger.addEventListener('click', switchTheme);
});

/* Functions
-------------------------------------------------- */

function setThemeOnStartup() {
    if (localStorage.hasOwnProperty(themeKeyName)) {
        const currentTheme = localStorage.getItem(themeKeyName);
        
        switchToTheme(currentTheme);
    }
}

function switchTheme() {
    if (localStorage.hasOwnProperty(themeKeyName)) {
        const currentTheme = localStorage.getItem(themeKeyName);

        if (currentTheme === darkTheme) {
            switchToTheme(lightTheme);
        } else {
            switchToTheme(darkTheme);
        }
    } else {
        switchToTheme(lightTheme);
    }
}

function switchToTheme(theme = darkTheme) {
    localStorage.setItem(themeKeyName, theme);
    addClass(root, theme);
}