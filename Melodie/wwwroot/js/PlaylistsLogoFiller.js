/* Const
-------------------------------------------------- */

class PlaylistLogo {
    logo = null;
    titleContainer = null;
    acronym = '';
    
    constructor(logo, titleContainer) {
        this.logo = logo;
        this.titleContainer = titleContainer;
    }
    
    isTitleContainerAnInput() {
        if (this.titleContainer == null) return false;
        
        return this.titleContainer.tagName.toLowerCase() === 'input' ||
                this.titleContainer.tagName.toLowerCase() === 'textarea';
    }
    
    getTitle() {
        if (this.titleContainer == null) return '';
        let title;
        
        if (this.isTitleContainerAnInput()) {
            title = this.titleContainer.value;
        } else {
            title = this.titleContainer.textContent;
        }
        
        return title;
    }
    
    buildAcronym(title) {
        this.acronym = title.match(/\b(\w)/g).join('').toUpperCase();
    }
    
    setAcronym() {
        if (this.logo == null) return;
        
        this.buildAcronym(this.getTitle());
        this.logo.setAttribute('data-acronym', this.acronym);
    }
}

const logos = [];

/* Set all acronyms
-------------------------------------------------- */

document.addEventListener('DOMContentLoaded', function(event) {
    const playlists = document.querySelectorAll('.playlist-block, #playlist-info') || [];

    forEach(playlists, function (index, playlist) {
        const logo = playlist.querySelector('.playlist-logo.auto-acronym');
        const titleContainer = playlist.querySelector('.playlist-title');

        if (logo != null) {
            logos[index] = new PlaylistLogo(logo, titleContainer);
            logos[index].setAcronym();

            if (logos[index].isTitleContainerAnInput()) {
                logos[index].titleContainer.addEventListener('change', function () {
                    logos[index].setAcronym()
                }, false);
            }
        }
    });
});