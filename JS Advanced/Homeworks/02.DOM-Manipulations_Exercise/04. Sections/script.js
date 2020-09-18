function create(words) {

   const content = document.getElementById('content');

   for (const word of words) {
      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = word;

      let div = document.createElement('div');
      div.appendChild(p);

      div.addEventListener('click', displayText);
      function displayText() {
         this.firstChild.style.display = 'block';
      }

      content.appendChild(div);
   }
}
