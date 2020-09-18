function stopwatch() {
    const timeElement = document.getElementById('time');

    let minutes = 0,
        seconds = 0,
        counter;

    const startBtn = document.getElementById('startBtn');
    startBtn.addEventListener('click', start);

    const stopBtn = document.getElementById('stopBtn');
    stopBtn.addEventListener('click', stop);

    function add() {
        seconds++;
        if (seconds >= 60) {
            seconds = 0;
            minutes++;
        }

        timeElement.textContent = (minutes ? (minutes > 9 ? minutes : "0" + minutes) : "00") + ":" + (seconds > 9 ? seconds : "0" + seconds);
    }

    function start() {
        seconds = 0;
        minutes = 0;
        timeElement.textContent = '00:00';
        startBtn.disabled = true;
        stopBtn.disabled = false;
        counter = setInterval(add, 1000);
    }

    function stop() {
        clearInterval(counter);
        startBtn.disabled = false;
        stopBtn.disabled = true;
    }
}