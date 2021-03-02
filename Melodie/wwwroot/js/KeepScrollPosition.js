/* Set scroll position at page load
-------------------------------------------------- */

document.addEventListener('DOMContentLoaded', function(event) {
    if (localStorage['page'] === document.URL) {
        document.documentElement.scrollTo(localStorage['scroll'], 0);
    }
});

/* Save scroll position
-------------------------------------------------- */

document.addEventListener('scroll', function () {
    localStorage['page'] = document.URL;
    localStorage['scroll'] = document.documentElement.scrollTop;
})