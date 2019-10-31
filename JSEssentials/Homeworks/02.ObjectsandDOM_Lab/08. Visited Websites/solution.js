// function solve() {

//   let siteElements = document.getElementsByClassName('link-1');

//   for (const siteElement of siteElements) {
//       siteElement.addEventListener('click', (e) => {
//           let currentTarget = e.currentTarget;
//           let p = currentTarget.getElementsByTagName('p')[0];

//           let text = p.textContent;
//           let textParts = text.split(' ');
//           let clicks = Number(textParts[1]);
//           clicks++;
//           textParts[1] = clicks;
//           p.textContent = textParts.join(' ');
//       });
//   }
// }

function solve() {

  let linkElements = document.getElementsByClassName('link-1');

  for (let i = 0; i <linkElements.length ; i++) {
      linkElements[i].addEventListener('click',onClick)
  }

  function onClick() {
      let pElement =this.getElementsByTagName('p')[0];
      let text =  pElement.textContent.split(" ");
      Number(text[1]++);

      this.getElementsByTagName('p')[0].textContent=text.join(" ");
  }
}