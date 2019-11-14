function validate() {
    function checkInput() {
        if (!pattern.test(this.value)) {
            this.classList.add('error');
        } else {
            this.classList.remove('error');
        }
    }

    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', checkInput);
    let pattern = /^([a-z]+)@([a-z]+)\.([a-z]+)$/;
}