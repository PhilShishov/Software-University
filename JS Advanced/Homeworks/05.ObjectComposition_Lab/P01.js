function orderRectangle(data) {
    const rects = [];

    for (const [width, height] of data) {
        const rect = comparator(width, height);
        rects.push(rect);
    }

    rects.sort((a, b) => a.compareTo(b));

    return rects;

    function comparator(w, h) {
        const rect = {
            width: w,
            height: h,
            area: () => rect.width * rect.height,
            compareTo: function (other) {
                const result = other.area() - rect.area();
                return result || (other.width - rect.width);
            }
        };    
        return rect;
    }
}

console.log(orderRectangle([[10, 5], [5, 12]]));
console.log(orderRectangle([[10, 5], [3, 20], [5, 12]]));