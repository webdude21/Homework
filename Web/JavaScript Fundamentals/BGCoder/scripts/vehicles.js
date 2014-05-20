function solve(params) {
    var wheelCount = parseInt(params[0]);
    var combinationsFound = 0;
    for (var trucks = 0; trucks < wheelCount; trucks++) {
        for (var cars = 0; cars < wheelCount; cars++) {
            for (var trikes = 0; trikes < wheelCount; trikes++) {
                if ((trucks * 10 + cars * 4 + trikes * 3) === wheelCount) {
                    combinationsFound++;
                }
            }
        }
    }
    return combinationsFound;
}