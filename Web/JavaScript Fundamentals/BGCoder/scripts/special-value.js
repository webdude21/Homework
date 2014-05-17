function solve(input) {
    input.shift();
    var pathEnded = false;
    var visited = [];
    var maxSpecialValue = 0;

    for (var row = 0; row < input.length; row++) {
        input[row] = input[row].split(', ');
        for (var col = 0; col < input[row].length; col++) {
            input[row][col] = parseInt(input[row][col]);
        }
    }

    for (var startCol = 0; startCol < input[0].length; startCol++) {
        pathEnded = false;
        var steps = 0;
        col = startCol;
        var specialValue = 0;
        for (row = 0; row < input.length; row++) {
            visited[row] = [];
        }

        while (!pathEnded) {
            for (row = 0; row < input.length; row++) {
                if (col >= input[row].length || visited[row][col]) {
                    pathEnded = true;
                    break;
                }
                if (col < 0) {
                    specialValue = steps + Math.abs(col);
                    pathEnded = true;
                    break;
                }
                steps++;
                visited[row][col] = true;
                col = input[row][col];
            }
        }
        maxSpecialValue = Math.max(maxSpecialValue, specialValue);
    }
    return maxSpecialValue;
}