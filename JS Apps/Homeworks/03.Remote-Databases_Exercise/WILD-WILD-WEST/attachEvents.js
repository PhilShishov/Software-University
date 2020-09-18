function attachEvents() {

    const user = {
        appId: "kid_rJQd9Uyv8",
        appSecret: "39bfef437ae34a9b86825315c90e9dfc",
        username: "guest",
        password: "guest"
    };

    const URL = `https://baas.kinvey.com/appdata/${user.appId}/players`;
    const AUTH = {
        "Authorization": 'Basic ' + btoa(user.username + ':' + user.password),
        "Content-type": "application/json",
    };
    const DOMElements = {
        canvas: document.getElementById("canvas"),
        addPlayerBtn: document.getElementById("addPlayer"),
        saveBtn: document.getElementById("save"),
        reloadBtn: document.getElementById("reload"),
        playerNameInput: document.getElementById("addName"),
        players: document.getElementById("players"),

    };
    DOMElements.addPlayerBtn.addEventListener("click", addPlayer);

    function addPlayer() {
        const player = {
            name: DOMElements.playerNameInput.value,
            money: 500,
            bullets: 6,
        };

        fetch(URL, {
            method: "POST",
            headers: AUTH,
            body: JSON.stringify(player)
        }).then(() => DOMElements.players.innerHTML = "")
            .then(loadAllPlayer)

        document.getElementById("addName").value = '';
    }

    function loadAllPlayer() {
        fetch(URL, {
            headers: AUTH,
        })
            .then(response => response.json())
            .then(data => data.forEach(p => appendPlayerToDom(p)))
    }
    loadAllPlayer();
    function appendPlayerToDom(data) {
        const divElement = document.createElement("div");
        divElement.classList.add("player");
        divElement.setAttribute("id", data._id);
        divElement.innerHTML = `<div class="name">Name: ${data.name}</div>
                          <div class="money">Money: ${data.money}</div>
                          <div class="bullets">Bullets: ${data.bullets}</div>
                          <div class="buttons">
                              <div class="play-button">
                                 <button>Play</button>
                              </div>
                              <div class="delete-button">
                                 <button>Delete</button>
                              </div>
                          </div>`;
        const playBtn = divElement.getElementsByClassName("play-button")[0];
        const deleteBtn = divElement.getElementsByClassName("delete-button")[0];
        playBtn.addEventListener("click", () => { play(data) });
        deleteBtn.addEventListener("click", () => {
            deletePlayer(data._id)
        });
        DOMElements.players.appendChild(divElement);
    }

    function play(player) {
        DOMElements.canvas.style.display = "block";
        DOMElements.saveBtn.style.display = "inline-block";
        DOMElements.reloadBtn.style.display = "inline-block";
        DOMElements.saveBtn.addEventListener("click", () => { savePlayerStats(player) });
        DOMElements.reloadBtn.addEventListener("click", () => { reloadBullets(player) });
        loadCanvas(player);
    }
    function reloadBullets(player) {
        player.money -= 60;
        player.bullets = 6;
    }
    function savePlayerStats(player) {
        fetch(URL + "/" + player._id, {
            method: "PUT",
            headers: AUTH,
            body: JSON.stringify(player)
        })
            .then(stopGame)
            .then(() => DOMElements.players.innerHTML = "")
            .then(() => location.reload())
            .then(loadAllPlayer);

    }
    function stopGame() {
        DOMElements.canvas.style.display = "none";
        DOMElements.saveBtn.style.display = "none";
        DOMElements.reloadBtn.style.display = "none";
    }
    function deletePlayer(id) {
        fetch(URL + "/" + id, {
            method: "DELETE",
            headers: AUTH
        })
            .then(() => DOMElements.players.innerHTML = "")
            .then(loadAllPlayer);
    }
}