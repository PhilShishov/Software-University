// function vectorMath() {
//     return {
//         add: function (v1, v2) {
//             let x1 = v1[0];
//             let y1 = v1[1];
//             let x2 = v2[0];
//             let y2 = v2[1];
//             let result = [];
//             result[0] = x1 + x2;
//             result[1] = y1 + y2;
//             return console.log(result);
//         },
//         multiply: function (v1, num) {
//             let result = [];
//             result[0] = v1[0] * num;
//             result[1] = v1[1] * num;
//             return console.log(result);
//         },
//         length: function (v1) {
//             let x = v1[0];
//             let y = v1[1];
//             let result = Math.sqrt(x * x + y * y);
//             return console.log(result);
//         },
//         dot: function (v1, v2) {
//             let x1 = v1[0];
//             let y1 = v1[1];
//             let x2 = v2[0];
//             let y2 = v2[1];
//             let result = x1 * x2 + y1 * y2;
//             return console.log(result);
//         },
//         cross: function (v1, v2) {
//             let x1 = v1[0];
//             let y1 = v1[1];
//             let x2 = v2[0];
//             let y2 = v2[1];
//             let result = x1 * y2 - y1 * x2;
//             return console.log(result);
//         }
//     };
// }

// vectorMath().add([1, 1], [1, 0]);
// vectorMath().multiply([3.5, -2], 2);
// vectorMath().length([3, -4]);
// vectorMath().dot([1, 0], [0, -1]);
// vectorMath().cross([3, 7], [1, 0]);

vectorMath = (() => {
    const add = (vector1, vector2) => [vector1[0] + vector2[0], vector1[1] + vector2[1]];
    const multiply = (vector1, scala) => [vector1[0] * scala, vector1[1] * scala];
    const length = vector1 => Math.sqrt(vector1[0] * vector1[0] + vector1[1] * vector1[1]);
    const dot = (vector1, vector2) => vector1[0] * vector2[0] + vector1[1] * vector2[1];
    const cross = (vector1, vector2) => vector1[0] * vector2[1] - vector1[1] * vector2[0];
    return {
        add: add,
        multiply: multiply,
        length: length,
        dot: dot,
        cross: cross
    }
})();

vectorMath = (() => {
    const add = (vector1, vector2) => [vector1[0] + vector2[0], vector1[1] + vector2[1]];
    const multiply = (vector1, scala) => [vector1[0] * scala, vector1[1] * scala];
    const length = vector1 => Math.sqrt(vector1[0] * vector1[0] + vector1[1] * vector1[1]);
    const dot = (vector1, vector2) => vector1[0] * vector2[0] + vector1[1] * vector2[1];
    const cross = (vector1, vector2) => vector1[0] * vector2[1] - vector1[1] * vector2[0];
    return {
        add: console.log(add([1, 1], [1, 0])),
        multiply: console.log(multiply([3.5, -2], 2)),
        length: console.log(length([3, -4])),
        dot: console.log(dot([1, 0], [0, -1])),
        cross: console.log(cross([3, 7], [1, 0]))
    }
})();