"use strict";
class Ticket {
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}
function parseTickets(data) {
    let tickets = [];
    for (const line of data) {
        let tokens = line.split('|');
        let ticket = new Ticket(tokens[0], Number.parseFloat(tokens[1]), tokens[2]);
        tickets.push(ticket);
    }
    return tickets;
}
function sortTickets(tickets, criteria) {
    let sortedTickets = [];
    if (criteria == 'destination') {
        sortedTickets = tickets.sort((firstTicket, secondTicket) => {
            return firstTicket.destination.localeCompare(secondTicket.destination);
        });
    }
    else if (criteria == 'status') {
        sortedTickets = tickets.sort((firstTicket, secondTicket) => {
            return firstTicket.status.localeCompare(secondTicket.status);
        });
    }
    else if (criteria == 'price') {
        sortedTickets = tickets.sort((firstTicket, secondTicket) => {
            if (firstTicket.price > secondTicket.price) {
                return 1;
            }
            return -1;
        });
    }
    else {
        throw Error('Invalid sorting criteria');
    }
    return sortedTickets;
}
function startUp(data, criteria) {
    let tickets = parseTickets(data);
    let sortedTickets = sortTickets(tickets, criteria);
    console.log(sortedTickets);
}
let inputTickets = [
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
];
startUp(inputTickets, 'destination');
//# sourceMappingURL=tickets.js.map