function attachGradientEvents() {
    function gradientMove(event) {
        let power = event.offsetX / (event.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        document.getElementById('result').textContent = `${power}%`;
    }

    function gradientOut() {
        document.getElementById('result').textContent = '';
    }

    let gradientElement = document.getElementById('gradient');
    gradientElement.addEventListener('mousemove', gradientMove);
    gradientElement.addEventListener('mouseout', gradientOut);
}