function fly() {

    window.requestAnimFrame = (function requestAnimFrame() {
        return window.requestAnimationFrame || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame || window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame;
    })();

    var canvas = document.getElementById("the-canvas");
    var context = canvas.getContext("2d");
    context.lineWidth = "2";
    context.fillStyle = "#90cad7";
    context.strokeStyle = "#358295";
    var xIncrease = true;
    var yIncrease = true;
    var circleRadius = parseInt(document.getElementById("it-radius").value) || 5;
    var speed = parseInt(document.getElementById("it-speed").value) || 1;
    var x = circleRadius;
    var y = circleRadius;

    function animate() {

        xIncrease ? x += speed : x -= speed;
        yIncrease ? y += speed : y -= speed;

        if (x + circleRadius >= canvas.width || x - circleRadius <= 0) {
            xIncrease = !xIncrease;
        }
        if (y + circleRadius >= canvas.height || y - circleRadius <= 0) {
            yIncrease = !yIncrease;
        }

        context.clearRect(0, 0, canvas.width, canvas.height);
        context.drawCircle(x, y, circleRadius);
        context.stroke();
        context.fill();

        requestAnimFrame(function () {
            animate();
        });
    }

    animate();
}
