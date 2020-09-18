function squareOfStars(num = 5) {

    for (let i = 0; i < num; i++) {
        console.log('*'.repeat(num).split('').join(' '));
    }
}

squareOfStars(1);
squareOfStars(2);
squareOfStars(5);
squareOfStars();