function deckOfCards(deck) {

    const cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const cardSuites = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666 ',
        C: '\u2663'
    };

    let cards = [];
    try {
        for (const input of deck) {
            const face = input.slice(0, input.length - 1);
            const suit = input.substr(input.length - 1);

            if (!cardFaces.includes(face) || !cardSuites.hasOwnProperty(suit)) {
                throw new Error(`Invalid card: ${face + suit}`);
            }

            const card = {
                cardFace: face,
                cardSuit: cardSuites[suit],
                toString: function () {
                    return this.cardFace + this.cardSuit;
                }
            };

            cards.push(card);
        }
    } catch (error) {
        console.log(error.message);
        return;
    }

    console.log(cards.join(' '));
}

deckOfCards(['AS', '10D', 'KH', '2C']);
deckOfCards(['5S', '3D', 'QD', '1C']);