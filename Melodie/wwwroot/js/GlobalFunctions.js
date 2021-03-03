/** Custom foreach **/
const forEach = function (array, callback, scope) {
    for (let i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]);
    }
}

/** Get DOM element style **/
function getStyle(el, styleProp)
{
    if (el.currentStyle)
        return el.currentStyle[styleProp];

    return document.defaultView.getComputedStyle(el,null)[styleProp];
}

/** Classes **/
function addClass(el, className) {
    el.className = el.className.trim() + ' ' + className;
}

function delClass(el, className) {
    el.className = el.className.replace(new RegExp("\\b"+className+"\\b", "g"), "");
}