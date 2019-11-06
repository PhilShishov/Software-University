function solve() {
   let searchField = document.getElementById('searchField');
   let searchBtn = document.getElementById('searchBtn');
   let tableElements = document.getElementsByTagName("tbody").item(0).getElementsByTagName("tr");

   searchBtn.addEventListener('click', onclick);

   function onclick(){
      let text = searchField.value.toLowerCase();

      for (let row of tableElements){
         row.removeAttribute("class");
         if (row.textContent.toLowerCase().includes(text)){
             row.className="select";
         }
     }
     document.getElementById("searchField").value="";
   }
}