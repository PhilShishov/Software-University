function toggle() {
    const extraDiv = document.getElementById('extra');
    const textBtn = document.getElementsByClassName('button')[0];

    if (extraDiv.style.display === 'block') {
        extraDiv.style.display = 'none';
        textBtn.innerHTML = 'More';
    }
    else {
        extraDiv.style.display = 'block';
        textBtn.innerHTML = 'Less';
    }
}