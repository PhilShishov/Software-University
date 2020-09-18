function playingCards(cardFace, cardSuit) {
    const cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const cardSuites = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666 ',
        C: '\u2663'
    };

    if (!cardFaces.includes(cardFace) || !cardSuites.hasOwnProperty(cardSuit)) {
        throw new Error();
    }

    let card = {
        cardFace: cardFace,
        cardSuit: cardSuites[cardSuit]
    };

    return card.cardFace + card.cardSuit;
}

console.log(playingCards('A', 'S'));
console.log(playingCards('10', 'H'));
console.log(playingCards('1', 'C'));
console.log(playingCards('J', 'D'));