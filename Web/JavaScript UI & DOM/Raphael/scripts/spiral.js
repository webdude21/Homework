window.onload = function drawSpiral() {
    var paper = Raphael(10, 10, 1000, 500),
        rad = Math.PI / 180,
        totalSpiralRadius = 200,
        spiralDensity = 0.2;

    drawSpiral(400, 300, 5, 0, 5);

    function drawSpiral(cx, cy, radius, startAngle, endAngle) {
        var currentStartAngle = startAngle,
            currentEndAngle = endAngle,
            currentRadius = radius,
            buffer;

        while (currentRadius < totalSpiralRadius) {
            arc(cx, cy, currentRadius, currentStartAngle, currentEndAngle);

            currentRadius += spiralDensity;
            buffer = currentStartAngle;
            currentStartAngle = currentEndAngle;
            currentEndAngle = buffer + 5;
        }
    }

    function arc(cx, cy, r, startAngle, endAngle) {
        var x1 = cx + r * Math.cos(-startAngle * rad),
            x2 = cx + r * Math.cos(-endAngle * rad),
            y1 = cy + r * Math.sin(-startAngle * rad),
            y2 = cy + r * Math.sin(-endAngle * rad);
        paper.path(["M", x1, y1, "A", r, r, 0, +(endAngle - startAngle > 180), 0, x2, y2]);
    }
};