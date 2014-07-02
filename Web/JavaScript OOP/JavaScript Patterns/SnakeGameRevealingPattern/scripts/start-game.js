(function () {
    var runGame = function runGame() {
        if (snakeGame.snake.isAlive) {
            snakeGame.gameField.clearRect(0, 0, snakeGame.gameCanvas.width, snakeGame.gameCanvas.height);
            snakeGame.drawGameObjects(snakeGame.gameObjects, 'blue');
            snakeGame.drawGameObjects(snakeGame.snake.body, 'green');
            snakeGame.decideInteraction(snakeGame.snake);
            requestAnimFrame(function () {
                runGame();
            });
        }
    };

    document.getElementById('btn-start').addEventListener('click', runGame);
}());