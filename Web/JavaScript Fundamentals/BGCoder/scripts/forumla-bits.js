function solve(params) {
    var track = [];

    for (var row = 0; row < 8; row++) {
        track[row] = [];

        for (var col = 0; col < 8; col++) {
            var bit = (params[row] >> (7 - col)) & 1;
            track[row][col] = parseInt(bit);
        }
    }

    var x = 7;
    var y = 0;
    var upOrDownCounter = 0;
    var countSteps = 1;
    var numberTurns = 0;
    var direction = "down";

    for (var steps = 0; steps < 8 * 8; steps++) {

        if (x == 0 && y == 7) {
            return (countSteps + " " + numberTurns);
        }

        if (track[y][x] === 1) {
            countSteps--;
            break;
        }

        switch (direction) {

            case "down":
                if ((y + 1 <= 7) && (track[y + 1][x] === 0)) {
                    y++;
                    countSteps++;
                }
                else if ((x - 1 >= 0) && (y + 1 <= 7) && (track[y + 1][x] == 1) && (track[y][x - 1] == 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else if ((y == 7) && (x - 1 >= 0) && (track[y][x - 1] == 0)) {
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
                if ((x - 1 >= 0) && (track[y][x - 1] == 0)) {
                    x--;
                    countSteps++;
                }
                else if ((x == 0) || (track[y][x - 1] == 1)) {
                    if ((upOrDownCounter % 2 == 1) && (y - 1 >= 0) && (track[y - 1][x] == 0)) {
                        y--;
                        countSteps++;
                        numberTurns++;
                        direction = "up";
                    }
                    else if ((upOrDownCounter % 2 == 0) && (y + 1 <= 7) && (track[y + 1][x] == 0)) {
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
                if ((y - 1 >= 0) && (track[y - 1][x] == 0)) {
                    y--;
                    countSteps++;
                }
                else if ((y - 1 >= 0) && (track[y - 1][x] == 1) && (x - 1 >= 0) && (track[y][x - 1] == 0)) {
                    x--;
                    countSteps++;
                    upOrDownCounter++;
                    numberTurns++;
                    direction = "left";
                }
                else if ((y == 0) && (x - 1 >= 0) && (track[y][x - 1] == 0)) {
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

    if (x == 0 && y == 7) {
        return (countSteps + " " + numberTurns);
    }
    else {
        return ("No " + countSteps);
    }
}