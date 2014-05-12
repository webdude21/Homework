function Solver(input) {
    var output = [];
    var indent = input[1];
    input = input.slice(2);
    var newLine = '\r\n';
    var indentCount = 0;
    var currentOutputLine;

    for (var i = 0; i < input.length; i++) {
        currentOutputLine = '';
        for (var j = 0; j < input[i].length; j++) {

            if (input[i][j] === '{') {
                currentOutputLine = currentOutputLine + newLine;
                currentOutputLine = indentAsNeeded(currentOutputLine);
                indentCount++;
            }
            else if (input[i][j] === '}') {
                indentCount--;
                currentOutputLine = currentOutputLine + newLine;
                currentOutputLine = indentAsNeeded(currentOutputLine);
            }
            else{
                currentOutputLine = currentOutputLine + input[i][j];
            }
        }
        output.push(currentOutputLine);
    }

    function indentAsNeeded(str) {
        for (var k = 0; k < indentCount; k++) {
            str = indent + str;
        }
        return str;
    }

    String.prototype.reduceWhiteSpace = function reduceWhiteSpace() {
        return this.trim().replace(/\s{2,}/gi, ' ')
    };

    return output;
}