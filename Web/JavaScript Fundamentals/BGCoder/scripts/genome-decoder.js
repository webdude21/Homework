function solve(input) {
    var N = parseInt(input[0].split(' ')[1]);
    var M = parseInt(input[0].split(' ')[0]);
    var lines = [];
    var result = '';

    if (!String.prototype.trimRight) {
        String.prototype.trimRight = function () {
            return ('$%&' + this).trim().slice(0, -3);
        }
    }

    function addLineNumbers() {
        var padding = lines.length.toString().length;
        var currentLineNumberLength;
        var lineNumber;
        for (var i = 0; i < lines.length; i++) {
            lineNumber = i + 1;
            currentLineNumberLength = (i + 1).toString().length;
            lineNumber = lineNumber.toString();
            result += multiplyString(' ', padding - currentLineNumberLength)
                + lineNumber + ' ' + lines[i] + '\n';
        }
    }

    function formatSequence(sequence) {
        var index = 0;
        var currentLine = '';
        while (index < sequence.length) {
            if (index + M < sequence.length) {
                currentLine = sequence.slice(index, index + M);
            }
            else {
                currentLine = sequence.slice(index, sequence.length);
            }
            lines.push(appendSpaces(currentLine, N));
            index += M;
        }
    }

    function appendSpaces(str, interval) {
        var outputStr = '';
        for (var index = 0; index < str.length; index++) {
            if (parseInt(index % interval) === 0 && index >= interval) {
                outputStr += ' ';
            }
            outputStr += str[index];
        }
        return outputStr;
    }

    function isDigit(char) {
        if (char >= '0' && char <= '9') return true;
    }

    function multiplyString(str, timesToMultiply) {
        var strOut = '';
        for (var times = 0; times < timesToMultiply; times++) {
            strOut += str;
        }
        return strOut;
    }

    function decodeSequence(sequence) {
        var index = 0;
        var char = '';
        var inNumber = false;
        var currentNumber = '';
        var output = '';

        while (index < sequence.length) {
            char = sequence[index];
            if (isDigit(char)) {
                currentNumber += char;
                inNumber = true;
            }
            else if (currentNumber === '') {
                output += char;
            }
            else {
                output += multiplyString(char, parseInt(currentNumber));
                currentNumber = '';
            }
            index++;
        }
        return output;
    }

    var decodedSequence = decodeSequence(input[1]);
    formatSequence(decodedSequence);
    addLineNumbers();

    return result.trimRight();
}