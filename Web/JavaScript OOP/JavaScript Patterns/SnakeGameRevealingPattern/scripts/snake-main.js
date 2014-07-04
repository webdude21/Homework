var snakeGame = (function () {
    // animation shim
    window.requestAnimFrame = (function requestAnimFrame() {
        return window.requestAnimationFrame || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame || window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
    })();

    // game variables initialization
    var gameCanvas = document.getElementById("the-canvas");
    var gameField = gameCanvas.getContext("2d");
    var gameObjects = [];
    var basicChunkSize = 5;
    document.getElementById('score').innerHTML = "Score: 0";
    var reachedInitialLength = false;
    var score = 0;
    var level = 10;
    var snake = snakeGameObjects.getSnake(50, 50, 2, basicChunkSize, 15, 10);
    attachKeyboardControl(snake, 'keydown');

    var apple = document.getElementById('apple');
    var stone = document.getElementById('stone');

    var foodGenerator = function () {
        return snakeGameObjects.objectGenerator(snakeGameObjects.generateRandomObject(gameCanvas, basicChunkSize),
            apple, 'food', gameObjects, doCollide);
    };

    var stoneGenerator = function () {
        return snakeGameObjects.objectGenerator(snakeGameObjects.generateRandomObject(gameCanvas, basicChunkSize),
            stone, 'stone', gameObjects, doCollide)
    };

    var foodGeneratorId = window.setInterval(foodGenerator, 5000);
    var stoneGeneratorId = window.setInterval(stoneGenerator, 10000);

    function drawGameObjects(objectsToDraw, color) {
        gameField.fillStyle = color;
        for (var i = 0; i < objectsToDraw.length; i++) {
            var obj = objectsToDraw[i];
            if (obj.image) {
                gameField.moveTo(obj.x, obj.y);
                gameField.drawImage(obj.image, obj.x, obj.y)
            } else {
                gameField.beginPath();
                gameField.drawCircle(objectsToDraw[i].x, objectsToDraw[i].y, objectsToDraw[i].width / 2);
                gameField.fill();
            }
        }
    }

    function gameOver() {
        var fontSize = 120;
        gameField.closePath();
        gameField.clearRect(0, 0, gameCanvas.width, gameCanvas.height);
        gameField.beginPath();
        gameField.font = fontSize + "px Tahoma";
        gameField.textAlign = 'center';
        gameField.fillStyle = 'red';
        gameField.fillText("Game Over", gameCanvas.width / 2, gameCanvas.height / 2);
        window.clearInterval(foodGeneratorId);
        window.clearInterval(stoneGeneratorId);
    }

    function updateScore() {
        document.getElementById('score').innerHTML = "Score: " + (score += level);
    }

    function decideInteraction(snake) {
        if (!inGameField(snake)) {
            snake.isAlive = false;
            gameOver();
        }

        if (snake.isAlive) {
            snake.update();
            snake.move();

            for (var i = 0; i < gameObjects.length; i++) {
                if (doCollide(gameObjects[i], snake.getHead())) {
                    if (gameObjects[i].type === 'food') {
                        snake.grow();
                        gameObjects.unset(gameObjects[i]);
                        updateScore();
                    } else {
                        snake.isAlive = false;
                        gameOver();
                    }
                }
            }

            for (var j = 0; j < snake.body.length - snake.growRate * 2; j++) {
                if (doCollide(snake.body[j], snake.getHead())) {
                    snake.isAlive = false;
                    gameOver();
                }
            }

            if (!reachedInitialLength) {
                snake.grow();
                if (snake.body.length >= snake.length) {
                    reachedInitialLength = true;
                }
            }
        }
    }

    function inGameField(snake) {
        var snakeSize = snake.segmentRadius / 2;
        if (snake.headX >= snakeSize && snake.headY >= snakeSize) {
            if (snake.headX + snakeSize <= gameCanvas.width && snake.headY + snakeSize <= gameCanvas.height) {
                return true;
            }
        }
    }

    function doCollide(firstObject, secondObject) {
        function collisionCheck(firstObject, secondObject) {
            if (secondObject.x < firstObject.x + firstObject.width &&
                secondObject.x > firstObject.x) {
                if (secondObject.y < firstObject.y + firstObject.height &&
                    secondObject.y > firstObject.y) {
                    return true
                }
            }
        }

        return collisionCheck(firstObject, secondObject) || collisionCheck(secondObject, firstObject);
    }

    return {
        decideInteraction: decideInteraction,
        drawGameObjects: drawGameObjects,
        snake: snake,
        gameField: gameField,
        gameCanvas: gameCanvas,
        gameObjects: gameObjects
    };
}());