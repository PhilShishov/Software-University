function solve() {

  let textAreaElements = document.getElementsByTagName("textarea");
  let buttonsElement = document.getElementsByTagName("button");
  let tbody = document.getElementsByTagName("tbody")[0];
  document.getElementsByTagName("input")[0].disabled = false;
  buttonsElement[0].addEventListener("click", generate);
  buttonsElement[1].addEventListener("click", buy);

  function generate() {

      let furnitureListInput = JSON.parse(textAreaElements[0].value);
      for (let i = 0; i < furnitureListInput.length; i++) {
          tbody.appendChild(document.getElementsByTagName("tr")[1].cloneNode(true));
          addFurniture(furnitureListInput[i]);
      }
  }

  function addFurniture(furniture) {
      let allFurnitureElements = document.getElementsByTagName("tr");
      let currentFurnitureElements = allFurnitureElements[allFurnitureElements.length - 1];
      currentFurnitureElements.getElementsByTagName("td")[0].innerHTML = `<img src=${furniture["img"]}>`;
      currentFurnitureElements.getElementsByTagName("td")[1].innerHTML = `<p>${furniture["name"]}</p>`;
      currentFurnitureElements.getElementsByTagName("td")[2].innerHTML = `<p>${furniture["price"]}</p>`;
      currentFurnitureElements.getElementsByTagName("td")[3].innerHTML = `<p>${furniture["decFactor"]}</p>`;
      currentFurnitureElements.getElementsByTagName("td")[4].innerHTML = `<input type="checkbox"/>`;
  }

  function buy() {
      let furniture = [];
      let totalPrice = 0;
      let averageFactor = 0;
      let checkbox = Array.from(document.getElementsByTagName("input"));
      for (let i = 0; i < checkbox.length; i++) {
          if (checkbox[i].checked) {
              let tableElements = checkbox[i].parentElement.parentElement;
              let name = tableElements.getElementsByTagName("p")[0].textContent;
              furniture.push(name);
              let price = tableElements.getElementsByTagName("p")[1].textContent;
              totalPrice += +price;
              let decFactor = tableElements.getElementsByTagName("p")[2].textContent;
              averageFactor += +decFactor;
          }
      }
      document.getElementsByTagName("textarea")[1].textContent += `Bought furniture: ${furniture.join(", ")}\n`;
      document.getElementsByTagName("textarea")[1].textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
      document.getElementsByTagName("textarea")[1].textContent += `Average decoration factor: ${averageFactor / furniture.length}`;
  }
}