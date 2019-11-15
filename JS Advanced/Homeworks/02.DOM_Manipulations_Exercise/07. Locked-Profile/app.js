function lockedProfile() {
    const buttons = document.getElementsByTagName('button');
    
    for (const btn of buttons) {
        btn.addEventListener('click', showMore);
    }

    function showMore(){
        let profileElement = this.parentNode;
        let unlockedRadioElement = profileElement.getElementsByTagName('input')[1]; 
        let lockedInformationDiv = profileElement.children[9];

        if (unlockedRadioElement.checked && this.textContent === 'Show more') {
            lockedInformationDiv.style.display = 'block';
            this.textContent = 'Hide it';
        } else if (unlockedRadioElement.checked && this.textContent === 'Hide it') {
            lockedInformationDiv.style.display = 'none';
            this.textContent = 'Show more';
        }
    }
}