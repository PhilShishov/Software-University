function attachEvents() {
  const comments = document.getElementById("post-comments");
  const posts = document.getElementById("posts");
  let allPosts = [];

  const btnLoad = document.getElementById("btnLoadPosts");
  const btnView = document.getElementById("btnViewPost");

  btnLoad.addEventListener("click", loadPosts);
  btnView.addEventListener("click", viewPost);

  function loadPosts() {
    posts.textContent = "";
    const url = "https://blog-apps-c12bf.firebaseio.com/posts.json";
    fetch(url)
      .then(parseData())
      .then(data => {
        // const values = Object.values(data);
        // const keys = Object.keys(data);

        let fragment = document.createDocumentFragment();

        for (const key in data) {
          if (data.hasOwnProperty(key)) {
            const element = data[key];
            allPosts.push(element);

            const option = document.createElement("option");
            option.value = element.id;
            option.textContent = element.title;
            fragment.appendChild(option);
          }
        }

        posts.appendChild(fragment);
      })
      .catch(printError());
  }

  function viewPost() {
    let postId = posts.value;

    for (let i = 0; i < allPosts.length; i++) {
      if (allPosts[i].id === postId) {
        document.getElementById(
          "post-title"
        ).innerHTML = `<h4>${allPosts[i].title}</h4>`;

        document.getElementById("post-body").innerHTML = allPosts[i].body;

        const url = "https://blog-apps-c12bf.firebaseio.com/comments.json";
        fetch(url)
          .then(parseData())
          .then(data => {
            for (const key in data) {
              if (data.hasOwnProperty(key)) {
                const element = data[key];

                if (element.postId == postId) {
                  const li = document.createElement("li");
                  li.innerHTML = element.text;

                  comments.appendChild(li);
                }
              }
            }
          })
          .catch(printError());

        return;
      }
    }
  }

  function parseData() {
    return resources => {
      if (!resources.ok) {
        throw new Error(
          JSON.stringify({
            status: resources.status,
            statusText: resources.statusText
          })
        );
      }
      return resources.json();
    };
  }

  function printError() {
    return errorData => {
      console.log(errorData.message);
    };
  }
}

attachEvents();
