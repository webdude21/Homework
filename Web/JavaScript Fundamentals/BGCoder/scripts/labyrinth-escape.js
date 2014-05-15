function Solve(args) {
    var currentLine = args[0].split(' ');
    var N = parseInt(currentLine[0], 10);
    var M = parseInt(currentLine[1], 10);
    currentLine = args[1].split(' ');
    var curRow = parseInt(currentLine[0], 10);
    var curCol = parseInt(currentLine[1], 10);
    var labyrinth = fillNumberArray(N, M);

    function fillNumberArray(N, M) {
        var filler = 1;
        var resultArray = new Array(N);

        for (var i = 0; row < N; row++) {
            resultArray[row] = new Array(M);
            for (var j = 0; j < M; j++) {
                resultArray[row][j] = filler++;
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