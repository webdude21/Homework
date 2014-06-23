var movingShapes = (function () {
    var interval = 60;

    function generateDiv() {
        var newDIv = document.createElement('div');
        newDIv.style.color = getRandomColor();
        newDIv.style.backgroundColor = getRandomColor();
        newDIv.style.border = getRandomInt(1, 20) + 'px solid ' + getRandomColor();
        newDIv.style.position = 'absolute';
        newDIv.style.top = getRandomInt(0, 800) + 'px';
        newDIv.style.left = getRandomInt(0, 1600) + 'px';
        newDIv.style.height = getRandomInt(20, 100) + 'px';
        newDIv.style.width = getRandomInt(20, 100) + 'px';
        newDIv.style.borderRadius = getRandomInt(0, 100000) + 'px';
        newDIv.className = 'my-div';
        return newDIv
    }

    function getRandomColor() {
        return '#' + Math.floor(Math.random() * 16777215).toString(16);
    }

    function getRandomInt(from, to) {
        return Math.floor(Math.random() * (to - from) + from);
    }

    function addMovingShape(type) {
        var div = generateDiv();
        div.setAttribute('movementConst', 0);
        document.body.appendChild(div);
        if (type == 'rect') {
            moveThatRect(div);
        }
        else {
            moveElement(div);
        }

    }

    var rectX = 600;
    var rectY = 600;

    function moveThatRect(div) {
        function rectMovement() {
            var movement = parseInt(div.getAttribute('movementConst'));
            movement += 3;
            if (movement == 360) {
                movement = 0;
            }

            if (movement <= 90) {
                var x = (rectX * (movement / 90));
                div.style.left = x + "px";
            }
            else if (movement <= 180) {
                var y = (rectY * ((movement - 90) / 90));
                div.style.top = y + "px";
            }
            else if (movement <= 270) {
                var x2 = (rectX - rectX * ((movement - 180) / 90));
                div.style.left = x2 + "px";
            }
            else {
                var y2 = (rectY - rectY * ((movement - 270) / 90));
                div.style.top = y2 + "px";
            }

            div.setAttribute('movementConst', movement);
        }

        setInterval(rectMovement, interval);
    }

    var ellX = 300;
    var ellY = 150;
    var ellR = 150;

    function moveElement(div) {
        function elementMoment() {
            var movement = parseInt(div.getAttribute('movementConst'));
            movement += 3;
            if (movement == 360) {
                movement = 0;
            }

            var left = ellX + Math.cos((2 * 3.14 / 180) * (movement)) * ellR;
            var right = 2 * (ellY + Math.sin((2 * 3.14 / 180) * (movement)) * ellR);
            div.style.left = left + "px";
            div.style.top = right + "px";

            div.setAttribute('movementConst', movement);
        }

        setInterval(elementMoment, interval);
    }

    return {
        add: addMovingShape
    };
}());