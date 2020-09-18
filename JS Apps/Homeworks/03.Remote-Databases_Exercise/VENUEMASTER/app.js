const user = {
    appId: "kid_BJXTsSi-e",
    appSecret: "447b8e7046f048039d95610c1b039390",
    username: "guest",
    password: "pass"
};

const POST_URL = `https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/calendar?query=`;
const GET_URL = `https://baas.kinvey.com/appdata/kid_BJ_Ke8hZg/venues/`;

const AUTH = {
    "Authorization": 'Basic ' + btoa(user.username + ':' + user.password),
    "Content-type": "application/json",
};

const DOMElements = {
    listVenuesBtn: document.getElementById("getVenues"),
    venuesDate: document.getElementById("venueDate"),
    venueInfo: document.getElementById("venue-info"),
};

DOMElements.listVenuesBtn.addEventListener("click", getVenuesId);

function getVenuesId() {
    DOMElements.venueInfo.innerHTML = "";
    const date = DOMElements.venuesDate.value;
    fetch(POST_URL + date, {
        method: "POST",
        headers: AUTH
    })
        .then(response => response.json())
        .then(data => data.forEach(id => getVenues(id)));
}

function getVenues(id) {
    fetch(GET_URL + id, {
        headers: AUTH
    })
        .then(response => response.json())
        .then(data => appendVenueToDOM(data))
}

function appendVenueToDOM(venue) {
    const divElement = document.createElement("div");
    divElement.classList.add("venue");
    divElement.setAttribute("id", `${venue._id}`);
    divElement.innerHTML = ` <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
                             <div class="venue-details" style="display: none;">
                                  <table>
                                     <tr>
                                       <th>Ticket Price</th>
                                       <th>Quantity</th>
                                       <th></th>
                                     </tr>
                                     <tr>
                                         <td class="venue-price">${venue.price} lv</td>
                                         <td><select class="quantity">
                                                 <option value="1">1</option>
                                                 <option value="2">2</option>
                                                 <option value="3">3</option>
                                                 <option value="4">4</option>
                                                 <option value="5">5</option>
                                             </select></td>
                                         <td><input class="purchase" type="button" value="Purchase"></td>
                                     </tr>
                                  </table>
                                  <span class="head">Venue description:</span>
                                  <p class="description">${venue.description}</p>
                                  <p class="description">Starting time: ${venue.startingHour}</p>
                             </div>`;
    const moreInfoBtn = divElement.getElementsByClassName("venue-name")[0];
    const purchaseBtn = divElement.getElementsByClassName("purchase")[0];
    purchaseBtn.addEventListener("click", (ev)=>purchaseTickets(ev,venue._id,venue.name,venue.price));
    moreInfoBtn.addEventListener("click", loadMoreInfo);
    DOMElements.venueInfo.appendChild(divElement);
}

function loadMoreInfo(ev) {
    const moreInfoMenu = ev.target.parentNode.parentNode.children[1];
    moreInfoMenu.style.display = "block";
}

function purchaseTickets(ev,id,name) {
    const ticketsInfoTable = ev.target.parentNode.parentNode;
    const quantity = ticketsInfoTable.getElementsByClassName("quantity")[0].value;
    let ticketPrice = ticketsInfoTable.getElementsByClassName("venue-price")[0].textContent;
    ticketPrice = parseInt(ticketPrice.substring(0, ticketPrice.length - 3));

    DOMElements.venueInfo.innerHTML = `<span class="head">Confirm purchase</span>
                                      <div class="purchase-info">
                                        <span>${name}</span>
                                        <span>${quantity} x ${ticketPrice}</span>
                                        <span>Total: ${quantity * ticketPrice} lv</span>
                                        <input type="button" value="Confirm">
                                      </div>`;
    const confirmBtn = DOMElements.venueInfo.getElementsByTagName("input")[0];
    confirmBtn.addEventListener("click", function () {
        confirmPurchase(id, quantity)
    });
}

function confirmPurchase(id, qty) {
    fetch(`https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${id}&qty=${qty}`, {
        method: "POST",
        headers: AUTH
    })
        .then(response => response.json())
        .then(data => {
            DOMElements.venueInfo.innerHTML = "You may print this page as your ticket." + data.html;
        })
}