function loadRepos() {

   const reposList = document.getElementById('repos');

   const statusChecker = {
      isSuccess: (status) => status === 200,
   };

   const parseRepo = ({ html_url, full_name }) => {
      return { link: html_url, name: full_name };
   };

   const toDomElement = ({name, link}) => {
      const listItem = document.createElement('li');
      const linkItem = document.createElement('a');
      linkItem.href = link;
      linkItem.innerHTML = name;
      listItem.appendChild(linkItem);
      return listItem;
   };

   const handleResponse = function () {
      if (this.readyState < 4) {
         return;
      }

      if (!statusChecker.isSuccess(this.status)) {
         return;
      }

      // const repos = JSON.parse(this.response);
      // // console.log(repos);

      JSON.parse(this.response)
         .map(parseRepo)
         .map(toDomElement)
         .forEach(el => {
            reposList.appendChild(el);
         });
   };

   const req = new XMLHttpRequest();
   req.onreadystatechange = handleResponse;

   req.open("GET",
      "https://api.github.com/users/testnakov/repos", true);
   req.send();
}

// function loadRepos() {

//    const httpRequest = new XMLHttpRequest();
//    httpRequest.addEventListener('readystatechange', function () {
//       if (httpRequest.readyState === 4 && httpRequest.status === 200) {
//          document.getElementById("res").textContent = httpRequest.responseText;
//       }
//    });
//    httpRequest.open("GET", 'https://api.github.com/users/testnakov/repos');
//    httpRequest.send();
// }