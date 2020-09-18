function notify(message) {
    const notification = document.getElementById('notification');

    let p = document.createElement('p');
    p.textContent = message;

    notification.appendChild(p);
    notification.style.display = 'block';

    setTimeout(fade_out, 2000);

    function fade_out() {
        notification.style.display = 'none';
    }
}