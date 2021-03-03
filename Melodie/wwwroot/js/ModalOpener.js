document.addEventListener('DOMContentLoaded', function() {
    const modalOpeners = document.querySelectorAll('.btn[data-open-modal]');
    
    forEach(modalOpeners, function (index, opener) {
        opener.addEventListener("click", function (e) {
            openModal(e.target)
        });
    });

    const modalClosers = document.querySelectorAll('.btn[data-close-modal]');

    forEach(modalClosers, function (index, closer) {
        closer.addEventListener("click", function (e) {
            closeModal(e.target)
        });
    });
});

function openModal(opener) {
    const modalId = opener.dataset.openModal;
    const modal = getModalById(modalId);
    
    showModal(modal);
}

function closeModal(closer) {
    const modalId = closer.dataset.closeModal;
    const modal = getModalById(modalId);
    
    showModal(modal, false);
}

function getModalById(id) {
    return document.querySelector('.modal[data-modal-id="'+id+'"]');
}

function showModal(modal, show = true) {
    if (show) {
        addClass(modal, 'open');
        addClass(document.body, 'no-scroll');
    } else {
        delClass(modal, 'open');
        delClass(document.body, 'no-scroll');
    }
    
}