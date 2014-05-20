function solve(params) {
    var answer = 0;
    var previousNumber = Number.MAX_VALUE;

    for (var i = 1; i < params.length; i++) {
        var currentNumber = parseInt(params[i], 10);
        if (currentNumber < previousNumber) {
            answer++;
        }
        previousNumber = currentNumber;
    }
    return answer;
}
