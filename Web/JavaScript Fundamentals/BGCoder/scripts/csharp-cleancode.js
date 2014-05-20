function solve(input) {
    input.shift();
    var text = input.join('\n');
    var bufferLine = '';
    var output = '';
    var chr = 0;
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
            return false;
        };
    }

    while (chr < text.length) {
        escaping = false;
        if (text[chr] === '\\' && !inVerbatimString) {
            escaping = true;
            if (!inLineComment && !inMultiLineComment && !inSummary) {
                bufferLine += text[chr] + text[chr + 1];
            }
            chr += 2;
            continue;
        }
        if (!escaping) {
            if (!inLineComment) {
                if (!inString && !inVerbatimString) {
                    if (!inSummary) {
                        if (!inMultiLineComment && text.substring(chr, chr + 3) === "///" && text[chr + 4] !== "/") {
                            bufferLine += '///';
                            inSummary = true;
                            chr += 3;
                            continue;
                        }
                        if (text.substring(chr, chr + 2) === "*/") {
                            inMultiLineComment = false;
                            chr += 2;
                            continue;
                        }
                        if (text.substring(chr, chr + 2) === "/*") {
                            inMultiLineComment = true;
                            chr += 2;
                            continue;
                        }
                        if (text.substring(chr, chr + 2) === "//" && !inMultiLineComment) {
                            inLineComment = true;
                            chr += 2;
                            continue;
                        }
                    }
                }
                if (!inMultiLineComment && !inLineComment && !inSummary) {
                    if (text[chr] === '"') {
                        if (inVerbatimString) {
                            if (text[chr + 1] !== '"') {
                                inVerbatimString = !inVerbatimString;
                            }
                            bufferLine += text[chr];
                            chr += 1;
                            continue;
                        } else if (inString) {
                            inString = false;
                            bufferLine += text[chr];
                            chr += 1;
                            continue;
                        }
                        if (text[chr - 1] === '@') {
                            inVerbatimString = true;
                            bufferLine += text[chr];
                            chr += 1;
                            continue;
                        } else {
                            inString = true;
                            bufferLine += text[chr];
                            chr += 1;
                            continue;
                        }
                    }
                }
            }
        }
        if (text[chr] === '\n') {
            inSummary = false;
            inLineComment = false;
            inString = false;
            if (!bufferLine.isNullOrEmpty()) {
                output += bufferLine;
            }
            bufferLine = '';
        }
        if (!inMultiLineComment && !inLineComment) {
            bufferLine += text[chr];
        }
        chr++;
    }
    return (output + bufferLine).trim();
}