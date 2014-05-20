function solve(input) {
    var valley = input[0].split(', ');
    input = input.slice(2);
    var patterns = [];
    var maxCoin = -Infinity;

    for (var i = 0; i < input.length; i++) {
        patterns[i] = input[i].trim().split(', ');
    }

    for (var pattern = 0; pattern < patterns.length; pattern++) {
        var position = 0;
        var visited = [];
        var coins = parseInt(valley[position]);
        visited[position] = true;
        var escaped = false;

        while (!escaped) {
            for (var index = 0; index < patterns[pattern].length; index++) {
                position = parseInt(patterns[pattern][index], 10) + position;
                if (position >= valley.length || position < 0 || visited[position]) {
                    escaped = true;
                    break;
                }
                coins += parseInt(valley[position]);
                visited[position] = true;
            }
        }
        maxCoin = Math.max(coins, maxCoin);
    }
    return maxCoin;
}