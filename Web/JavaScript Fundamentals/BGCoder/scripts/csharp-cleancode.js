function Solver(input) {
    input.shift();
    var text = input.join('\n');
    var bufferLine = '';
    var output = '';
    var char = 0;
    var inMultiLineComment = false;
    var inLineComment = false;
    var inString = false;
    var escaping = false;
    var inVerbatimString = false;
    var inSummary = false;

    if (!String.prototype.isNullOrEmpty) {
        String.prototype.isNullOrEmpty = function () {
            if (this === '' || this === null || this.trim() === '') {
                return true;
            }
        }
    }

    while (char < text.length) {
        escaping = false;
        if (text[char] === '\\' && !inVerbatimString) {
            escaping = true;
            if (!inLineComment && !inMultiLineComment && !inSummary) {
                bufferLine += text[char] + text[char + 1];
            }
            char += 2;
            continue;
        }
        if (!escaping) {
            if (!inLineComment) {
                if (!inString && !inVerbatimString) {
                    if (!inSummary) {
                        if (!inMultiLineComment && text.substring(char, char + 3) === "///" && text[char + 4] !== "/") {
                            bufferLine += '///';
                            inSummary = true;
                            char += 3;
                            continue
                        }
                        if (text.substring(char, char + 2) === "*/") {
                            inMultiLineComment = false;
                            char += 2;
                            continue
                        }
                        if (text.substring(char, char + 2) === "/*") {
                            inMultiLineComment = true;
                            char += 2;
                            continue
                        }
                        if (text.substring(char, char + 2) === "//" && !inMultiLineComment) {
                            inLineComment = true;
                            char += 2;
                            continue
                        }
                    }
                }
                if (!inMultiLineComment && !inLineComment && !inSummary) {
                    if (text[char] === '"') {
                        if (inVerbatimString) {
                            if (text[char + 1] !== '"') {
                                inVerbatimString = !inVerbatimString;
                            }
                            bufferLine += text[char];
                            char += 1;
                            continue;
                        }
                        else if (inString) {
                            inString = false;
                            bufferLine += text[char];
                            char += 1;
                            continue
                        }
                        if (text[char - 1] === '@') {
                            inVerbatimString = true;
                            bufferLine += text[char];
                            char += 1;
                        }
                        else {
                            inString = true;
                            bufferLine += text[char];
                            char += 1;
                        }
                    }
                }
            }
        }
        if (text[char] === '\n') {
            inSummary = false;
            inLineComment = false;
            inString = false;
            if (!bufferLine.isNullOrEmpty()) {
                output += bufferLine;
            }
            bufferLine = '';
        }
        if (!inMultiLineComment && !inLineComment) {
            bufferLine += text[char];
        }
        char++;
    }
    return (output + bufferLine).trim();
}