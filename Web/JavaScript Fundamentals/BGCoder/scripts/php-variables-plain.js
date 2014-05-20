function solve(input) {
    var text = input.join('\n');
    var result = [];
    var chr = 0;
    var inMultiLineComment = false;
    var inLineComment = false;
    var inString = false;
    var currentCommentType = 'none';
    var escaping = false;
    var inVariable = false;
    var currentVariable = '';

    function addVariable(variable) {
        if (result.indexOf(variable) === -1 && variable !== '') {
            result.push(variable);
        }
    }

    function isValidVariableChar(character) {
        if (character >= 'a' && character <= 'z') {
            return true;
        }
        if (character >= 'A' && character <= 'Z') {
            return true;
        }
        if (character >= '0' && character <= '9') {
            return true;
        }
        return character === '_';
    }

    while (chr < text.length) {
        escaping = false;
        if (text[chr] === '\\') {
            escaping = true;
            chr += 2;
            if (inVariable) {
                inVariable = false;
                addVariable(currentVariable);
                currentVariable = '';
            }
            continue;
        }
        if (!escaping) {
            if (!inLineComment) {
                if (!inString) {
                    if (text.substring(chr, chr + 2) === "*/") {
                        inMultiLineComment = false;
                        chr += 2;
                        continue;
                    }
                    if (text[chr] === '#') {
                        inLineComment = true;
                    }

                    if (text.substring(chr, chr + 2) === "/*") {
                        inMultiLineComment = true;
                        chr += 2;
                        continue;
                    }
                    if (text.substring(chr, chr + 2) === "//") {
                        inLineComment = true;
                        chr += 2;
                        continue;
                    }
                }
                if (!inMultiLineComment && !inLineComment) {
                    if (text[chr] === '"' || text[chr] === "'") {
                        if (currentCommentType === 'none') {
                            currentCommentType = text[chr];
                            inString = true;
                        } else if (inString && currentCommentType === text[chr]) {
                            inString = false;
                            currentCommentType = 'none';
                        }
                    }
                    if (text[chr] === '$') {
                        if (inVariable) {
                            addVariable(currentVariable);
                            currentVariable = '';
                        }
                        inVariable = true;
                    } else if (inVariable) {
                        if (isValidVariableChar(text[chr])) {
                            currentVariable += text[chr];
                        } else {
                            inVariable = false;
                            addVariable(currentVariable);
                            currentVariable = '';
                        }
                    }
                }
            }
            if (text[chr] === '\n') {
                inLineComment = false;
                inString = false;
            }
        }
        chr++;
    }
    result.sort();
    return result.length > 0 ? result.length + ('\n') + result.join('\n') : '0';
}