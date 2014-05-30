function startGame() {
    window.requestAnimFrame = (function requestAnimFrame() {
        return window.requestAnimationFrame || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame || window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame;
    })();

    var gameCanvas = document.getElementById("the-canvas");
    var gameField = gameCanvas.getContext("2d");
    var gameObjects = [];
    var basicChunkSize = 5;
    document.getElementById('score').innerHTML = "Score: 0";
    var apple = document.getElementById('apple');
    var stone = document.getElementById('stone');
    var reachedInitialLength = false;
    var score = 0;
    var level = 10;

    function createGameObject(x, y, w, h) {
        return {
            x: x || 0,
            y: y || 0,
            width: w || 1,
            height: h || 1
        }
    }

    function generateRandomObject(objectCreator, objectsArray, image, type) {
        var randomX = Math.floor((Math.random() * (gameCanvas.width - basicChunkSize) + basicChunkSize));
        var randomY = Math.floor((Math.random() * (gameCanvas.height - basicChunkSize) + basicChunkSize));
        objectsArray.push(objectCreator(randomX, randomY, image, type));
    }

    var objectGenerator = function objectGenerator(x, y, image, type) {
        var newObject = createGameObject(x, y, image.width, image.height);
        newObject.image = image;
        newObject.type = type;
        return newObject;
    };

    Array.prototype.unset = function (value) {
        if (this.indexOf(value) !== -1) { // Make sure the value exists
            this.splice(this.indexOf(value), 1);
        }
    };

    function makeSnake(x, y, movementRate, basicChunkSize, initialLength, growRate, initialDirection) {
        return {
            segmentRadius: basicChunkSize || 5,
            headX: x || 50,
            headY: y || 50,
            isAlive: true,
            movementRate: movementRate || 1,
            direction: initialDirection || 'down',
            body: [],
            length: initialLength || 15,
            getHead: function () {
                return this.body[this.body.length - 1];
            },
            createSnakeBodyPart: function () {
                var that = this;
                return {
                    x: that.headX || 0,
                    y: that.headY || 0,
                    width: that.segmentRadius * 2 || 1,
                    height: that.segmentRadius * 2 || 1,
                    type: 'snakeBody'
                }
            },
            grow: function grow() {
                var rate = growRate || 1;
                for (var i = 0; i < rate; i++) {
                    this.body.push(this.createSnakeBodyPart());
                    if (this.body.length > this.length) {
                        this.length++;
                    }
                }
            },
            update: function () {
                this.body.shift();
                this.body.push(this.createSnakeBodyPart());
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
                gameField.drawCircle(objectsToDraw[i].x, objectsToDraw[i].y, objectsToDraw[i].width / 2);
                gameField.fill();
            }
        }
    }

    var snake = makeSnake(50, 50, 2, basicChunkSize, 15, 10);
    attachKeyboardControl(snake);
    var foodGeneratorId = setInterval(generateRandomObject(objectGenerator, gameObjects, apple, 'food'), 5000);
    var stoneGeneratorId = setInterval(generateRandomObject(objectGenerator, gameObjects, stone, 'stone'), 10000);

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
                    }
                    else {
                        snake.isAlive = false;
                        gameOver();
                    }
                }
            }

            for (var j = 0; j < snake.body.length - basicChunkSize * 2; j++) {
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

    function runGame() {
        if (snake.isAlive) {
            gameField.clearRect(0, 0, gameCanvas.width, gameCanvas.height);
            decideInteraction(snake);
            drawGameObjects(gameObjects, 'blue');
            drawGameObjects(snake.body, 'green');
            drawGameObjects(snake.body, 'green');
            requestAnimFrame(function () {
                runGame();
            });
        }
    }

    runGame();
}