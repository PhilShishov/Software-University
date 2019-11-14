function solve(input) {
    switch (input) {
        case 'upvote':
            this.upvotes++;
            break;

        case 'downvote':
            this.downvotes++;
            break;

        case 'score':
            return score(this);
    }

    function score(obj) {
        let modifier = 0;

        if (obj.upvotes + obj.downvotes > 50) {
            modifier = Math.ceil(Math.max(obj.upvotes, obj.downvotes) * 0.25);
        }

        let score = obj.upvotes - obj.downvotes;
        let rating = '';

        if (obj.upvotes + obj.downvotes < 10) {
            rating = 'new';

        } else if (score < 0) {
            rating = 'unpopular';

        } else if (obj.upvotes / (obj.upvotes + obj.downvotes) > 0.66) {
            rating = 'hot';

        } else if (obj.upvotes > 100 || obj.downvotes > 100) {
            rating = 'controversial';

        } else {
            rating = 'new';
        }

        return [obj.upvotes + modifier,
            obj.downvotes + modifier,
            score,
            rating];
    }
}

//Sample execution
let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solve.call(post, 'upvote');
solve.call(post, 'downvote');
console.log(solve.call(post, 'score'));

for (let i = 0; i < 50; i++) {
    solve.call(post, 'downvote');
}

console.log(solve.call(post, 'score'));