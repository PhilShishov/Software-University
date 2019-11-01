function growingWord() {

  let pElements = document.getElementsByTagName("p");
  let paragraph = pElements[pElements.length-1];

  let currentSize = Number(paragraph.style.fontSize.slice(0,-2))===0?1:paragraph.style.fontSize.slice(0,-2);
  paragraph.style.fontSize = `${currentSize * 2}px`;
  let colors = ["blue","green","red","pink"];
  let counter =colors.indexOf((paragraph.style.color));
  paragraph.style.color = colors[++counter%4];
}