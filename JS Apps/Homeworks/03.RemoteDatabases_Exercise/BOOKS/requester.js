const username = "guest";
const password = "guest";

const baseUrl = "https://baas.kinvey.com";
const appKey = "kid_rJQd9Uyv8";
const appSecret = "39bfef437ae34a9b86825315c90e9dfc";
const authToken = "c9e58205-7835-4da4-92a6-d2e6f75f6ee6.e/u34LXkuOj5KbUg6UBE/jVsAHNA2W+jWTEXYhlVnps=";

function makeHeaders(method, data) {
    const headers = {
        method: method,
        // Authorization: 'Kinvey ' + authToken,
        headers: {
            "Authorization": `Basic ${btoa(`${username}:${password}`)}`,
            "Content-Type": "application/json"
        }
    };

    if (method === "POST" || method === "PUT") {
        headers.body = JSON.stringify(data);
    }

    return headers;
}

function handleError(e) {
    if (!e.ok) {
        throw new Error(`${e.status} - ${e.statusText}`);
    }

    return e;
}

function serializeData(x) {
    return x.json();
}

function fetchRequest(kinveyModule, endpoint, headers) {
    const url = `${baseUrl}/${kinveyModule}/${appKey}/${endpoint}`;
    return fetch(url, headers)
        .then(handleError)
        .then(serializeData);
}

export function get(kinveyModule, endpoint) {
    const headers = makeHeaders("GET");
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function post(kinveyModule, endpoint, data) {
    const headers = makeHeaders("POST", data);
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function put(kinveyModule, endpoint, data) {
    const headers = makeHeaders("PUT", data);
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function del(kinveyModule, endpoint) {
    const headers = makeHeaders("DELETE");
    return fetchRequest(kinveyModule, endpoint, headers);
}