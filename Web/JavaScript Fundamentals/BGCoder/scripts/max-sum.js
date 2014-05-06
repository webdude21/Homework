function Solve(params) {
    var currentMaxSum = 0;
    var maxSum = -Number.MAX_VALUE;

    for (var i = 1; i < params.length; i++) {
        currentMaxSum = 0;
        for (var j = i; j < params.length; j++) {
            currentMaxSum += parseInt(params[j],10);
            if (currentMaxSum > maxSum) {
                maxSum = currentMaxSum;
            }
        }
    }
    return maxSum;
}