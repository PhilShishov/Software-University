function attachEvents() {
  const phonebook = document.getElementById("phonebook");
  const btnLoad = document.getElementById("btnLoad");
  btnLoad.addEventListener("click", loadContacts);

  const btnCreate = document.getElementById("btnCreate");
  btnCreate.addEventListener("click", createContact);

  const url = "https://phonebook-nakov.firebaseio.com/phonebook.json";

  function createContact() {
    const person = document.getElementById("person").value;
    const phone = document.getElementById("phone").value;

    const headers = {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        person,
        phone
      })
    };
    fetch(url, headers)
      .then(() => {
        document.getElementById("person").value = "";
        document.getElementById("phone").value = "";
        phonebook.innerHTML = "";
        loadContacts();
      })
      .catch(() => console.log("Error"));
  }

  function loadContacts() {
    fetch(url)
      .then(resources => resources.json())
      .then(data => {
        phonebook.innerHTML = "";
        Object.entries(data).forEach(([elementId, phoneBook]) => {
          const { person, phone } = phoneBook;

          const li = document.createElement("li");
          li.textContent = `${person}: ${phone}`;
          const deleteButton = document.createElement("button");
          deleteButton.textContent = "Delete";
          deleteButton.id = elementId;
          deleteButton.addEventListener("click", deleteContact);
          li.appendChild(deleteButton);
          phonebook.appendChild(li);
        });
      })
      .catch(() => console.log("Error"));
  }

  function deleteContact() {
    const id = this.getAttribute("id");
    const headers = {
      method: "DELETE"
    };

    fetch(
      `https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`,
      headers
    )
      .then(() => {
        phonebook.innerHTML = "";
        loadContacts();
      })
      .catch(() => console.log("Error"));
  }
}

attachEvents();
