async function loadCommits() {
  const username = document.getElementById("username").value;
  const repository = document.getElementById("repo").value;
  const commitsDiv = document.getElementById("commits");
  commitsDiv.innerHTML = "";

  const url = `https://api.github.com/repos/${username}/${repository}/commits`;

  try {
    await fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error(
            JSON.stringify({
              status: response.status,
              statusText: response.statusText
            })
          );
        }

        return response.json();
      })
      .then(data => {
        const commits = data.map(item => item.commit);

        for (const commit of commits) {
          const li = document.createElement("li");
          li.textContent = `${commit.author.name}: ${commit.message}`;
          commitsDiv.appendChild(li);
        }
      });
  } catch (errorData) {
    const error = JSON.parse(errorData.message);
    const li = document.createElement("li");
    li.textContent = `Error: ${error.status} (${error.statusText})`;
    commitsDiv.appendChild(li);
  }
}
