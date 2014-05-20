function solve(input) {
    var rows = parseInt(input[0].split(' ')[0]);
    var cols = parseInt(input[0].split(' ')[1]);
    input.shift();
    var numberArray = fillArray(rows, cols);

    function fillArray(rows, cols) {
        var resultArray = new Array(rows);
        for (var row = 0; row < rows; row++) {
            var filler = Math.pow(2, row);
            resultArray[row] = new Array(cols);
            for (var col = 0; col < cols; col++) {
                resultArray[row][col] = filler++;
            }
        }
        return resultArray;
    }

    var labyrinth = new Array(rows);
    for (var row = 0; row < rows; row++) {
        labyrinth[row] = input[row].split(' ');
    }

    function getNextStep(curRow, curCol, instruction) {
        var nextRow = curRow;
        var nextCol = curCol;

        switch (instruction) {
            case 'dr':
                nextCol++;
                nextRow++;
                break;
            case 'ur':
                nextRow--;
                nextCol++;
                break;
            case 'ul':
                nextRow--;
                nextCol--;
                break;
            case 'dl':
                nextRow++;
                nextCol--;
                break;
        }

        return {
            row: nextRow,
            col: nextCol
        };
    }

    // first step
    var sumOfNumber = numberArray[0][0];
    numberArray[0][0] = 0;
    var nextStep;
    var curRow = 0;
    var curCol = 0;

    while (true) {
        nextStep = getNextStep(curRow, curCol, labyrinth[curRow][curCol]);
        curRow = nextStep.row;
        curCol = nextStep.col;

        if ((curRow < rows && curRow >= 0) && (curCol < cols && curCol >= 0)) {
            if (numberArray[curRow][curCol] > 0) {
                sumOfNumber += numberArray[curRow][curCol];
                numberArray[curRow][curCol] = 0;
            } else {
                return "failed at (" + curRow + ', ' + curCol + ')';
            }
        } else {
            return "successed with " + sumOfNumber;
        }
    }
}