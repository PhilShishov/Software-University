function attachEvents() {
  const textAreaMessages = document.getElementById("messages");

  const btnRefresh = document.getElementById("refresh");
  btnRefresh.addEventListener("click", loadMessages);

  const btnSend = document.getElementById("submit");
  btnSend.addEventListener("click", sendMessage);

  const url = "https://rest-messanger.firebaseio.com/messanger.json";

  function loadMessages() {
    fetch(url)
      .then(resources => resources.json())
      .then(data => {
        const values = Object.values(data);

        for (const value of values) {
          textAreaMessages.innerHTML += `${value.author}: ${value.content}\n`;
        }
      })
      .catch(() => console.log("Error"));
  }

  function sendMessage() {
    const author = document.getElementById("author").value;
    const content = document.getElementById("content").value;
    const headers = {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        author,
        content
      })
    };
    fetch(url, headers)
      .then(() => {
        document.getElementById("author").value = "";
        document.getElementById("content").value = "";
        loadMessages();
      })
      .catch(() => console.log("Error"));
  }
}

attachEvents();
