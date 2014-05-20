function solve(input) {
    var charsPerLine = parseInt(input[1]);
    input = input.slice(2);
    var words = [];
    var output = '';
    var charsSoFar = -1;
    var NEW_LINE = "\r\n";
    var currentLine = [];

    function multiplyString(str, timesToMultiply) {
        var strOut = '';
        for (var times = 0; times < timesToMultiply; times++) {
            strOut += str;
        }
        return strOut;
    }

    for (var i = 0; i < input.length; i++) {
        words = words.concat(input[i].match(/\w+/gi));
    }

    for (var word = 0; word < words.length; word++) {
        var lineFinished = false;
        if (charsSoFar + words[word].length < charsPerLine) {
            currentLine.push(words[word]);
            charsSoFar += words[word].length + 1;
        } else {
            lineFinished = true;
            word--;
        }
        if (word === words.length - 1 || lineFinished) {
            if (currentLine.length > 1) {
                var wordCount = currentLine.length - 1;
                var availableSpace = charsPerLine - charsSoFar + wordCount;
                var minSpaceBetweenWords = parseInt(availableSpace / (wordCount));
                var whiteSpaceLeft = availableSpace - (minSpaceBetweenWords * wordCount);
            }
            if (currentLine.length === 1) {
                output += (currentLine[0]);
            } else {
                for (var wrd = 0; wrd < currentLine.length; wrd++) {
                    output += (currentLine[wrd]);
                    if (wrd < wordCount) {
                        output += multiplyString(' ', minSpaceBetweenWords);
                        if (whiteSpaceLeft) {
                            output += ' ';
                            whiteSpaceLeft--;
                        }
                    }
                }
            }
            output += NEW_LINE;
            charsSoFar = -1;
            currentLine = [];
        }
    }
    return output.trim();
}