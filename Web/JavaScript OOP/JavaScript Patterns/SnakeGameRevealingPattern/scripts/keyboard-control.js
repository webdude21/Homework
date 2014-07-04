var attachKeyboardControl = (function () {

    var KEY_LEFT = 37,
        KEY_UP = 38,
        KEY_RIGHT = 39,
        KEY_DOWN = 40;

    function attachKeyboardControl(snake, eventHandler) {

        var keyBoardHandler = function (event) {
            event = event || window.event;
            var upOrDown = snake.direction === 'up' || snake.direction === 'down';
            var leftOrRight = snake.direction === 'left' || snake.direction === 'right';
            switch (event.keyCode) {
                case KEY_LEFT:
                    if (upOrDown) {
                        snake.direction = 'left';
                    }
                    break;
                case KEY_UP:
                    if (leftOrRight) {
                        snake.direction = 'up';
                    }
                    break;
                case KEY_RIGHT:
                    if (upOrDown) {
                        snake.direction = 'right';
                    }
                    break;
                case KEY_DOWN:
                    if (leftOrRight) {
                        snake.direction = 'down';
                    }
                    break;
            }
        };
        document.addEventListener(eventHandler, keyBoardHandler);
    }

    return attachKeyboardControl
}());

