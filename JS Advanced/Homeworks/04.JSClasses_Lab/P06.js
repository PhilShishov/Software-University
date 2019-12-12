(function () {
    const suits = {
        CLUBS: '\u2663',
        DIAMONDS: '\u2666',
        HEARTS: '\u2665',
        SPADES: '\u2660'
    };

    const faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(face) {
            if (!faces.includes(face)) {
                throw new Error('Invalid face!');
            }

            this._face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(suit) {
            if (!Object.values(suits).some(s => s === suit)) {
                throw new Error('Invalid suit!');
            }

            this._suit = suit;
        }
    }

    return {
        Suits: suits,
        Card: Card
    }
}());