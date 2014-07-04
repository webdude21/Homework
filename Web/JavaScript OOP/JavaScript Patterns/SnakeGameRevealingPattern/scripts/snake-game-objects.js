var snakeGameObjects = (function () {

    function getNewGameObject(x, y, w, h) {
        return {
            x: x || 0,
            y: y || 0,
            width: w || 1,
            height: h || 1
        };
    }

    function generateRandomObject(gameCanvas, basicChunkSize) {
        var randomX = Math.floor((Math.random() * (gameCanvas.width - basicChunkSize) + basicChunkSize));
        var randomY = Math.floor((Math.random() * (gameCanvas.height - basicChunkSize) + basicChunkSize));
        return getNewGameObject(randomX, randomY);
    }

    var objectGenerator = function objectGenerator(newObject, image, type, gameObjects, doCollide) {
        var index = 0;

        while (index < gameObjects.length) {
            if (doCollide(gameObjects[index], newObject)) {
                break;
            } else {
                index++;
            }
        }

        newObject.image = image;
        newObject.type = type;
        newObject.width = image.width;
        newObject.height = image.height;
        gameObjects.push(newObject);
    };

    function getSnake(x, y, movementRate, basicChunkSize, initialLength, growRate, initialDirection) {
        return {
            segmentRadius: basicChunkSize || 5,
            headX: x || 50,
            headY: y || 50,
            isAlive: true,
            movementRate: movementRate || 1,
            direction: initialDirection || 'down',
            body: [],
            length: initialLength || 15,
            growRate: growRate || 1,
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
                for (var i = 0; i < this.growRate; i++) {
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

    return {
        getSnake: getSnake,
        generateRandomObject: generateRandomObject,
        objectGenerator: objectGenerator,
        getNewGameObject: getNewGameObject
    }
}());

