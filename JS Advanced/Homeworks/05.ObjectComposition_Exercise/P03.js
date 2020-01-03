function carFactory(order) {

    const engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];

    if (order.wheelsize % 2 === 0) {
        order.wheelsize = --order.wheelsize;
    }

    order = {
        model: order.model,
        engine: engines.filter(e => e.power >= order.power)[0],
        carriage: {
            type: order.carriage,
            color: order.color,
        },
        wheels: Array(4).fill(order.wheelsize),
        // wheels: [order.wheelsize, order.wheelsize, order.wheelsize, order.wheelsize],
    };

    return order;
}

console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));