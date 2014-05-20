function solve(args) {
    var currentLine = args[0].split(' ');
    var N = parseInt(currentLine[0], 10);
    var M = parseInt(currentLine[1], 10);
    currentLine = args[1].split(' ');
    var curRow = parseInt(currentLine[0], 10);
    var curCol = parseInt(currentLine[1], 10);
    var labyrinth = fillNumberArray(N, M);

    function fillNumberArray(rows, cols) {
        var filler = 1;
        var resultArray = new Array(rows);

        for (var row = 0; row < rows; row++) {
            resultArray[row] = new Array(cols);
            for (var col = 0; col < cols; col++) {
                resultArray[row][col] = filler++;
            }
        }
        return resultArray;
    }

    function getNextStep(curRow, curCol) {
        var nextRow = curRow;
        var nextCol = curCol;

        switch (args[curRow + 2][curCol]) {
            case 'l':
                nextCol--;
                break;
            case 'd':
                nextRow++;
                break;
            case 'r':
                nextCol++;
                break;
            case 'u':
                nextRow--;
                break;
        }

        return {
            row: nextRow,
            col: nextCol
        };
    }

    // first step
    var sumOfNumber = labyrinth[curRow][curCol];
    labyrinth[curRow][curCol] = 0;
    var numberOfJumps = 1;
    var nextStep;

    while (true) {
        nextStep = getNextStep(curRow, curCol);
        curRow = nextStep.row;
        curCol = nextStep.col;

        if ((curRow < N && curRow >= 0) && (curCol < M && curCol >= 0)) {

            if (labyrinth[curRow][curCol] > 0) {
                sumOfNumber += labyrinth[curRow][curCol];
                labyrinth[curRow][curCol] = 0;
                numberOfJumps++;
            } else {
                return "lost " + numberOfJumps;
            }
        } else {
            return "out " + sumOfNumber;
        }
    }
}