function solve(params) {
    var wheelCount = parseInt(params[0]);
    var combinationsFound = 0;
    var currentSolution;
    for (var trucks = 0; trucks <= wheelCount / 10; trucks++) {
        for (var cars = 0; cars <= wheelCount / 4; cars++) {
            for (var trikes = 0; trikes <= wheelCount / 3; trikes++) {
                currentSolution = trucks * 10 + cars * 4 + trikes * 3;
                if (currentSolution === wheelCount) {
                    combinationsFound++;
                } else if (currentSolution > wheelCount) {
                    break;
                }
            }
        }
    }
    return combinationsFound;
}