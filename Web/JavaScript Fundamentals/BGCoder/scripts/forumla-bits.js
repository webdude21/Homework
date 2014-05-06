function Solver(params) {
    //var params = [2, 38, 20, 48, 111, 15, 3, 43];

    var matrix = [];

    for (var row = 0; row < 8; row++) {
        matrix[row] = [];

        for (var col = 0; col < 8; col++) {
            var bit = (params[row] >> (7 - col)) & 1;
            matrix[row][col] = parseInt(bit);
            //process.stdout.write(matrix[row][col] + " ");
        }
        //console.log();
    }

    var x = 7;
    var y = 0;
    var upOrDownCounter = 0;
    var countSteps = 1;
    var numberTurns = 0;
    var direction = "down";

    for (var steps = 0; steps < 8 * 8; steps++) {

        switch (direction) {
            case "down":
                if ((y + 1 <= 7) && (matrix[y + 1][x] === 0)) {
                    y++;
                    countSteps++;
                }
                else if ((x - 1 >= 0) && (matrix[y + 1][x] === 1) && (matrix[y][x - 1] === 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else if ((y === 7) && (x - 1 >= 0) && (matrix[y][x - 1] === 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else {
                    break;
                }
                break;

            case "left":
                if ((x - 1 >= 0) && (matrix[y][x - 1] === 0)) {
                    x--;
                    countSteps++;
                }
                else if ((x === 0) || (matrix[y][x - 1] === 1)) {
                    if ((upOrDownCounter % 2 == 1) && (y - 1 >= 0) && (matrix[y - 1][x] === 0)) {
                        y--;
                        countSteps++;
                        numberTurns++;
                        direction = "up";
                    }
                    else if ((upOrDownCounter % 2 == 0) && (y + 1 <= 7) && (matrix[y + 1][x] === 0)) {
                        y++;
                        countSteps++;
                        numberTurns++;
                        direction = "down";
                    }
                    else {
                        break;
                    }
                }
                else {
                    break;
                }
                break;

            case "up":
                if ((y - 1 >= 0) && (matrix[y - 1][x] === 0)) {
                    y--;
                    countSteps++;
                }
                else if ((y - 1 >= 0) && (matrix[y - 1][x] === 1) && (x - 1 >= 0) && (matrix[y][x - 1] === 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else if ((y === 0) && (x - 1 >= 0) && (matrix[y][x - 1] === 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else {
                    break;
                }
        }
    }

    //console.log("turns: " + numberTurns);
    //console.log("direction: " + direction);
    //console.log("UpOrDOwn: " + upOrDownCounter);
    //console.log("X: " + x);
    //console.log("Y: " + y);
    //console.log("Steps: " + countSteps);

    if (x == 0 && y == 7) {
        return (countSteps + " " + numberTurns);
    }
    else {
        return ("No " + countSteps);
    }
}