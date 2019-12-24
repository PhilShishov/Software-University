function ticketManagement(ticketDescription, sortCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (const line of ticketDescription) {
        [destination, price, status] = line.split('|');

        const ticket = new Ticket(destination, +price, status);
        tickets.push(ticket);
    }

    switch (sortCriteria) {
        case 'destination':
            return tickets.sort((a, b) => a.destination.localeCompare(b.destination));

        case 'price':
            return tickets.sort((a, b) => a.price - b.price);

        case 'status':
            return tickets.sort((a, b) => a.status.localeCompare(b.status));
    }
}

ticketManagement(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
);

// ticketManagement(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'status'
// );