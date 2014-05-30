window.onload = function () {
    var theCanvas = document.getElementById("the-canvas");
    var canvas = theCanvas.getContext("2d");
    canvas.lineWidth = "2";
    canvas.fillStyle = "#90cad7";
    canvas.strokeStyle = "#358295";

    var faceX = 140;
    var faceY = 220;
    var rearWheelX = 75;
    var wheelsY = 430;

    canvas.drawCircle(rearWheelX, wheelsY, 60);
    canvas.fill();
    canvas.stroke();
    canvas.drawCircle(rearWheelX + 225, wheelsY, 60);
    canvas.fill();
    canvas.stroke();

    drawFace();
    drawBikeFrame(rearWheelX, wheelsY);
    drawHat();
    drawHouse(480, 175);

    function drawBikeFrame(startX, startY) {
        var x = startX;
        var y = startY;

        canvas.drawToOffSet = function (offsetX, offsetY) {
            x += offsetX;
            y += offsetY;
            this.lineTo(x, y)
        };

        canvas.moveToOffSet = function (offsetX, offsetY) {
            x += offsetX;
            y += offsetY;
            this.moveTo(x, y)
        };

        canvas.beginPath();
        canvas.moveTo(startX, startY);
        canvas.drawToOffSet(0, 0);
        canvas.drawToOffSet(105, -2);
        canvas.drawToOffSet(100, -80);
        canvas.drawToOffSet(20, 80);
        canvas.drawToOffSet(-30, -120);
        canvas.drawToOffSet(32, -32);
        canvas.drawToOffSet(-32, 32);
        canvas.drawToOffSet(-48, 17);
        canvas.moveToOffSet(58, 23);
        canvas.drawToOffSet(-145, 0);
        canvas.drawToOffSet(45, 80);
        var chainRingRadius = 15;
        canvas.stroke();
        canvas.drawCircle(x, y, chainRingRadius);
        canvas.stroke();
        canvas.moveToOffSet(-10, -10);
        canvas.drawToOffSet(-12, -12);
        canvas.moveToOffSet(32, 32);
        canvas.drawToOffSet(12, 12);
        canvas.moveToOffSet(-68, -102);
        canvas.drawToOffSet(-60, 83);
        canvas.moveToOffSet(61, -83);
        canvas.drawToOffSet(-13, -23);
        canvas.moveToOffSet(-25, 0);
        canvas.drawToOffSet(50, 0);
        canvas.closePath();
        canvas.stroke();
    }

    function drawFace() {
        canvas.strokeStyle = '#22545f';
        canvas.drawEllipse(faceX, faceY, 140, 130);
        canvas.fill();
        canvas.stroke();

        drawEye(faceX - 45, faceY - 20); // left eye
        drawEye(faceX + 5, faceY - 20); // right eye
        drawNose(faceX - 20, faceY + 15);

        canvas.save();
        canvas.rotate(0.15);
        canvas.drawEllipse(faceX + 17, faceY + 17, 50, 17);
        canvas.stroke();
        canvas.restore();


        function drawEye(x, y) {
            canvas.drawEllipse(x, y, 25, 17);
            canvas.stroke();
            canvas.drawEllipse(x - 4, y, 7, 15);
            canvas.stroke();
            var previousFillStyle = canvas.fillStyle;
            canvas.fillStyle = '#22545f';
            canvas.fill();
            canvas.fillStyle = previousFillStyle;
        }

        function drawNose(x, y) {
            canvas.moveTo(x, y);
            canvas.lineTo(x - 15, y);
            canvas.lineTo(x, y - 30);
            canvas.stroke();
        }

    }

    function drawHat() {
        canvas.fillStyle = "#396693";
        canvas.strokeStyle = "black";
        canvas.drawEllipse(faceX, faceY - 50, 170, 30);
        canvas.fill();
        canvas.stroke();
        canvas.fillRect(faceX - 40, faceY - 138, 85, 100);
        canvas.drawCylinder(faceX - 40, faceY - 148, 85, 100);
        canvas.fill();
        canvas.stroke();
    }

    function drawHouse(x, y) {
        canvas.fillStyle = "#975b5b";
        canvas.strokeStyle = "black";
        canvas.beginPath();
        canvas.fillRect(x, y, 286, 215);
        canvas.strokeRect(x, y, 286, 215);
        canvas.moveTo(x, y);
        canvas.lineTo(x + 143, y - 143);
        canvas.lineTo(x + 143 * 2, y);
        canvas.stroke();
        canvas.fill();
        drawChimney(x + 200, y - 110);
        drawDoor(x + 71, y + 215);
        drawWindow(x + 20, y + 25);
        drawWindow(x + 160, y + 25);
        drawWindow(x + 160, y + 118);
    }

    function drawChimney(x, y) {
        canvas.beginPath();
        canvas.drawEllipse(x + 15, y, 30, 8);
        canvas.fill();
        canvas.stroke();
        canvas.moveTo(x, y);
        canvas.lineTo(x, y + 80);
        canvas.moveTo(x + 30, y);
        canvas.lineTo(x + 30, y + 80);
        canvas.fillRect(x, y, 30, 70);
        canvas.fill();
        canvas.stroke();
    }

    function drawWindow(x, y) {
        canvas.fillStyle = "black";
        canvas.beginPath();
        canvas.fillRect(x, y, 50, 32);
        canvas.fillRect(x + 53, y, 50, 32);
        canvas.fillRect(x + 53, y + 35, 50, 32);
        canvas.fillRect(x, y + 35, 50, 32);
    }

    function drawDoor(x, y) {
        canvas.drawEllipse(x, y - 85, 80, 35);
        canvas.stroke();
        canvas.fillRect(x - 40, y - 85, 80, 80);
        canvas.beginPath();
        canvas.moveTo(x, y);
        canvas.lineTo(x, y - 103);
        canvas.moveTo(x - 40, y);
        canvas.lineTo(x - 40, y - 85);
        canvas.moveTo(x + 40, y);
        canvas.lineTo(x + 40, y - 85);
        canvas.stroke();
        canvas.drawCircle(x - 10, y - 30, 5);
        canvas.stroke();
        canvas.drawCircle(x + 10, y - 30, 5);
        canvas.stroke();
    }
};