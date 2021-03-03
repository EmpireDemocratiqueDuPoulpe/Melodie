/*
	By Osvaldas Valutis, www.osvaldas.info
	Available for use under the MIT License
	
	Edited by Empire Démocratique du Poulpe
*/

'use strict';

;(function (document, window, index)
{
    var inputs = document.querySelectorAll('.file-input input');
    Array.prototype.forEach.call(inputs, function(input)
    {
        var label = input.nextElementSibling,
            labelVal = label.innerHTML;

        input.addEventListener('change', function(e)
        {
            // If the input has an attribute "data-multiple-caption", it will show a text like "X files selected".
            // Else it will show the file name
            var fileName = '';
            if(this.files && this.files.length > 1)
                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
            else
                fileName = e.target.value.split('\\').pop();

            if(fileName)
                label.querySelector('span').innerHTML = fileName;
            else
                label.innerHTML = labelVal;
        });

        // Firefox bug fix
        input.addEventListener('focus', function(){ addClass(input, 'has-focus'); });
        input.addEventListener('blur', function(){ delClass(input, 'has-focus'); });
    });
}(document, window, 0));