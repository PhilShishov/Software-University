function solve() {
   const totalCostField = document.getElementById('myCourses').getElementsByClassName('courseFoot')[0].getElementsByTagName('p')[0];
   const btnAdd = document.getElementsByTagName('button')[0];
   const checkboxInputs = document.getElementsByTagName('input');
   btnAdd.addEventListener('click', addToMyCourses);

   let jsFundPrice = 170.00;
   let jsAdvPrice = 180.00;
   let jsAppPrice = 190.00;
   let jsWebPrice = 490.00;

   let totalCost = 0.00;
   let myCourses = [];

   function addToMyCourses() {
      let jsFund = checkboxInputs[0].checked;
      let jsAdv = checkboxInputs[1].checked;
      let jsApp = checkboxInputs[2].checked;
      let jsWeb = checkboxInputs[3].checked;
      let onsite = checkboxInputs[4].checked;
      let online = checkboxInputs[5].checked;

      if (online) {
         jsFundPrice = jsFundPrice * 0.94;
         jsAdvPrice = jsAdvPrice * 0.94;
         jsAppPrice = jsAppPrice * 0.94;
         jsWebPrice = jsWebPrice * 0.94;
      }

      if (jsFund) {
         totalCost += jsFundPrice;
         myCourses.push('JS-Fundamentals');
      }
      if (jsAdv) {
         if (jsFund && jsAdv) {
            jsAdvPrice = jsAdvPrice * 0.90;
         }
         myCourses.push('JS-Advanced');
         totalCost += jsAdvPrice;
      }
      if (jsApp) {
         totalCost += jsAppPrice;
         myCourses.push('JS-Applications');
      }

      if (jsWeb) {
         totalCost += jsWebPrice;
         myCourses.push('JS-Web');
      }

      if (jsFund && jsAdv && jsApp) {
         totalCost = jsFundPrice + jsAdvPrice + jsAppPrice;
         totalCost = totalCost * 0.94;
      }

      if (jsFund && jsAdv && jsApp && jsWeb) {
         totalCost += jsWebPrice;
         myCourses.push('HTML and CSS');
      }

      let myCoursesSection = document.getElementById('myCourses').getElementsByClassName('courseBody')[0].getElementsByTagName('ul')[0];

      for (const course of myCourses) {
         const li = document.createElement('li');
         li.textContent = course;

         myCoursesSection.appendChild(li);
      }

      totalCostField.textContent = `Cost: ${Math.floor(totalCost).toFixed(2)} BGN`;
   }
}

solve();