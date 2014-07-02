define(function () {
    return function (x, y, w, h) {
        return {
            x: x || 0,
            y: y || 0,
            width: w || 1,
            height: h || 1
        };
    }
});