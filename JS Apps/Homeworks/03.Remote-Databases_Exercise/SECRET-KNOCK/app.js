const user = {
    appId: "kid_BJXTsSi-e",
    appSecret: "447b8e7046f048039d95610c1b039390",
    username: "guest",
    password: "guest"
};

const URL = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock?query=`;

const AUTH = {
    "Authorization": 'Basic ' + btoa(user.username + ':' + user.password),
    "Content-type": "application/json",
};

let currentMessage = "Knock Knock.";

(async function getNextAnswer() {
    let response = await fetch(`${URL}${currentMessage}`, {
        headers: AUTH
    }).then(response => response.json());

    if (response.message) {
        console.log("Message: "+currentMessage);
        console.log("Answer: "+response.answer);
        currentMessage = response.message;
        getNextAnswer();
    } else {
        console.log("Message: "+currentMessage);
        console.log("Answer: "+response.answer);
    }
})();