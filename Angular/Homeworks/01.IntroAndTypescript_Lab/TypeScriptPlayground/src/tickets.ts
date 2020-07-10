class Ticket {
    constructor(
        public destination: string,
        public price: number,
        public status: string
    ) { }
}

function parseTickets(data: string[]): Ticket[] {
    let tickets: Ticket[] = [];

    for (const line of data) {
        let tokens: string[] = line.split('|');
        let ticket: Ticket = new Ticket(tokens[0], Number.parseFloat(tokens[1]), tokens[2]);
        tickets.push(ticket);
    }

    return tickets;
}

function sortTickets(tickets: Ticket[], criteria: string): Ticket[] {
    let sortedTickets: Ticket[] = [];
    if (criteria == 'destination') {
        sortedTickets = tickets.sort((firstTicket: Ticket, secondTicket: Ticket) => {
            return firstTicket.destination.localeCompare(secondTicket.destination);
        });
    }
    else if (criteria == 'status') {
        sortedTickets = tickets.sort((firstTicket: Ticket, secondTicket: Ticket) => {
            return firstTicket.status.localeCompare(secondTicket.status);
        });
    }
    else if (criteria == 'price') {
        sortedTickets = tickets.sort((firstTicket: Ticket, secondTicket: Ticket) => {
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

function startUp(data: string[], criteria: string) {
    let tickets: Ticket[] = parseTickets(data);
    let sortedTickets = sortTickets(tickets, criteria);

    console.log(sortedTickets);
}

let inputTickets: string[] = [
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
]

startUp(inputTickets, 'destination');