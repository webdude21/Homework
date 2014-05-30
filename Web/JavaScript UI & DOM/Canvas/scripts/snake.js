function startGame() {
    window.requestAnimFrame = (function requestAnimFrame() {
        return window.requestAnimationFrame || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame || window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame;
    })();

    var gameCanvas = document.getElementById("the-canvas");
    var gameField = gameCanvas.getContext("2d");
    var gameObjects = [];
    var basicChunkSize = 8;
    var magicVar = 1;
    var apple = document.getElementById('apple');

    function createGameObject(x, y, w, h) {
        return {
            x: x || 0,
            y: y || 0,
            width: w || 1,
            height: h || 1
        }
    }

    function generateFood() {
        var randomX = Math.floor((Math.random() * gameCanvas.width) + basicChunkSize);
        var randomY = Math.floor((Math.random() * gameCanvas.height) + basicChunkSize);
        gameObjects.push(createFoodObject(randomX, randomY, apple));
    }

    function createFoodObject(x, y, image) {
        var newFoodObject = createGameObject(x, y, image.width, image.height);
        newFoodObject.type = 'food';
        newFoodObject.image = image;
        return newFoodObject;
    }

    function createSnakeBodyPart(x, y, basicChunkSize) {
        var newBodyObject = createGameObject(x, y, basicChunkSize * magicVar, basicChunkSize * magicVar);
        newBodyObject.type = 'snakeBody';
        return newBodyObject;
    }

    Array.prototype.unset = function (value) {
        if (this.indexOf(value) !== -1) { // Make sure the value exists
            this.splice(this.indexOf(value), 1);
        }
    };

    function makeSnake(x, y, movementRate, basicChunkSize, initialDirection) {
        return {
            segmentRadius: basicChunkSize || 5,
            headX: x || 50,
            headY: y || 50,
            isAlive: true,
            movementRate: movementRate || 1,
            direction: initialDirection || 'down',
            body: [],
            getHead: function () {
                return this.body[this.body.length - 1];
            },
            grow: function grow() {
                this.body.push(createSnakeBodyPart(this.headX, this.headY, this.segmentRadius));
            },
            update: function () {
                this.body.shift();
                this.body.push(createSnakeBodyPart(this.headX, this.headY, this.segmentRadius));
            },
            move: function () {
                switch (this.direction) {
                    case 'down':
                        this.headY += movementRate;
                        break;
                    case 'up' :
                        this.headY -= movementRate;
                        break;
                    case 'left':
                        this.headX -= movementRate;
                        break;
                    case 'right':
                        this.headX += movementRate;
                        break;
                    default:
                        this.headY += movementRate;
                }
            }
        }
    }

    var attachKeyboardControl = function (snake) {
        document.onkeydown = function (event) {
            event = event || window.event;
            var upOrDown = snake.direction === 'up' || snake.direction === 'down';
            var leftOrRight = snake.direction === 'left' || snake.direction === 'right';
            switch (event.keyCode) {
                // left
                case 37:
                    if (upOrDown) {
                        snake.direction = 'left';
                    }
                    break;
                // up
                case 38:
                    if (leftOrRight) {
                        snake.direction = 'up';
                    }
                    break;
                // right
                case 39:
                    if (upOrDown) {
                        snake.direction = 'right';
                    }
                    break;
                // down
                case 40:
                    if (leftOrRight) {
                        snake.direction = 'down';
                    }
                    break;
            }
        }
    };

    function drawGameObjects(objectsToDraw, color) {
        gameField.fillStyle = color;
        for (var i = 0; i < objectsToDraw.length; i++) {
            var obj = objectsToDraw[i];
            if (obj.image) {
                gameField.moveTo(obj.x, obj.y);
                gameField.drawImage(obj.image, obj.x, obj.y)
            }
            else {
                gameField.beginPath();
                gameField.drawCircle(objectsToDraw[i].x, objectsToDraw[i].y, objectsToDraw[i].width);
                gameField.fill();
            }
        }
    }

    var snake = makeSnake(50, 50, 2, basicChunkSize);
    attachKeyboardControl(snake);
    var foodGeneratorId = setInterval(generateFood, 5000);

    function gameOver() {
        var fontSize = 120;
        gameField.clearRect(0, 0, gameCanvas.width, gameCanvas.height);
        gameField.beginPath();
        gameField.font = fontSize + "px Tahoma";
        gameField.textAlign = 'center';
        gameField.fillStyle = 'red';
        gameField.fillText("Game Over", gameCanvas.width / 2, gameCanvas.height / 2);
        window.clearInterval(foodGeneratorId);
    }

    function decideInteraction(snake) {
        if (!inGameField(snake)) {
            snake.isAlive = false;
            gameOver();
        }

        if (snake.isAlive) {
            for (var i = 0; i < gameObjects.length; i++) {
                if (doCollide(gameObjects[i], snake.getHead())) {
                    if (gameObjects[i].type === 'food') {
                        snake.grow();
                        gameObjects.unset(gameObjects[i]);
                    }
                }
            }

            snake.move();
            snake.update();
        }
    }

    function inGameField(snake) {
        if (snake.headX >= basicChunkSize && snake.headY >= basicChunkSize) {
            if (snake.headX + basicChunkSize <= gameCanvas.width && snake.headY + basicChunkSize <= gameCanvas.height) {
                return true;
            }
        }
    }

    function doCollide(firstObject, secondObject) {
        function collisionCheck(firstObject, secondObject) {
            if (secondObject.x < firstObject.x + firstObject.width &&
                secondObject.x > firstObject.x) {
                return true
            }
            if (secondObject.y < firstObject.y + firstObject.height &&
                secondObject.y > firstObject.y) {
                return true
            }
        }

        return collisionCheck(firstObject, secondObject) && collisionCheck(secondObject, firstObject);
    }

    function animate() {
        gameField.clearRect(0, 0, gameCanvas.width, gameCanvas.height);
        decideInteraction(snake);
        drawGameObjects(gameObjects, 'blue');
        drawGameObjects(snake.body, 'red');
        requestAnimFrame(function () {
            animate();
        });
    }

    animate();
}