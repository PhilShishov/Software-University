function solve() {
   function clickEvent() {
       function compareTwoCards(playerOneCard, playerTwoCard) {
           if (playerOneCardValue !== -1 && playerTwoCardValue !== -1) {
               if (playerOneCardValue > playerTwoCardValue) {
                   playerOneCard.style.border = '2px solid green';
                   playerTwoCard.style.border = '2px solid red';
               } else if (playerTwoCardValue > playerOneCardValue) {
                   playerOneCard.style.border = '2px solid red';
                   playerTwoCard.style.border = '2px solid green';
               }

               historyElement.textContent += (`[${playerOneCardValue} vs ${playerTwoCardValue}] `);

               setTimeout(() => {
                   playerOneSpanElement.textContent = '';
                   playerTwoSpanElement.textContent = '';
               }, 2000);
           }

           playerOneCardValue = -1;
           playerTwoCardValue = -1;
       }

       this.src = "images/whiteCard.jpg";

       if (this.parentNode === playerOneDivElement) {
           playerOneSpanElement.textContent = +playerOneSpanElement.textContent + +this.name;
           playerOneCardValue = +this.name;
           playerOneCard = this;
       } else if (this.parentNode === playerTwoDivElement) {
           playerTwoSpanElement.textContent = +playerTwoSpanElement.textContent + +this.name;
           playerTwoCardValue = +this.name;
           playerTwoCard = this;
       }

       if (playerOneCardValue !== -1 && playerTwoCardValue !== -1) {
           compareTwoCards(playerOneCard, playerTwoCard);
       }
   }

   let playerOneDivElement = document.getElementById('player1Div');
   let playerTwoDivElement = document.getElementById('player2Div');

   let playerOneCardElements = playerOneDivElement.getElementsByTagName('img');
   let playerTwoCardElements = playerTwoDivElement.getElementsByTagName('img');

   let resultElement = document.getElementById('result');
   let historyElement = document.getElementById('history');

   let playerOneSpanElement = resultElement.children[0];
   let playerTwoSpanElement = resultElement.children[2];

   let playerOneCardValue = -1;
   let playerTwoCardValue = -1;

   let playerOneCard = null;
   let playerTwoCard = null;

   for (let card of playerOneCardElements) {
       card.addEventListener('click', clickEvent);
   }

   for (let card of playerTwoCardElements) {
       card.addEventListener('click', clickEvent);
   }
}