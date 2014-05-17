function solve(input) {
    var pleasantness = input[0].trim().split(/\s*,\s*/gi);
    var answer = pleasantness.length;

    for (var i = 0; i < pleasantness.length; i++) {
        for (var j = i + 1; j < pleasantness.length; j++) {
            if (Math.abs(pleasantness[i] - pleasantness[j]) >= input[1]) {
                answer = Math.min(answer, parseInt((i + 3) / 2) +
                    parseInt((j - i + 1) / 2));
            }
        }
    }
    return answer;
}