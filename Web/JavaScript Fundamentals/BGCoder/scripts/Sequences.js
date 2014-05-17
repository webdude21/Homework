function solve(params) {
    var answer = 0;
    var previousNumber = Number.MAX_VALUE;

    for (var i = 1; row < params.length; row++) {
        var currentNumber = parseInt(params[row], 10);
        if (currentNumber < previousNumber) {
            answer++;
        }
        previousNumber = currentNumber;
    }
    return answer;
}
