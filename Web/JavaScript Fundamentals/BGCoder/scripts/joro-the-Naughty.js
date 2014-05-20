function solve(args) {
    var currentLine = args[0].split(' ');
    var N = parseInt(currentLine[0], 10);
    var M = parseInt(currentLine[1], 10);
    var jumps = parseInt(currentLine[2], 10);
    var rowPos = [];
    var colPos = [];
    var field = fillArray(N, M);

    for (var jumpIndex = 0; jumpIndex <= jumps; jumpIndex++) {
        currentLine = args[1 + jumpIndex].split(' ');
        rowPos.push(parseInt(currentLine[0], 10));
        colPos.push(parseInt(currentLine[1], 10));
    }

    function fillArray(rows, cols) {
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

    // start jump
    var curRow = rowPos[0];
    var curCol = colPos[0];
    var sumOfNumber = field[curRow][curCol];
    field[curRow][curCol] = 0;
    var numberOfJumps = 1;

    while (true) {
        for (var index = 1; index < rowPos.length; index++) {
            curRow += rowPos[index];
            curCol += colPos[index];
            if ((curRow < N && curRow + curRow >= 0) &&
                (curCol < M && curCol >= 0)) {
                if (field[curRow][curCol] > 0) {
                    sumOfNumber += field[curRow][curCol];
                    field[curRow][curCol] = 0;
                    numberOfJumps++;
                }
                else {
                    return "caught  " + numberOfJumps;
                }
            }
            else {
                return "escaped " + sumOfNumber;
            }
        }
    }
}