function Solver(input) {
    var text = input.join('\n');
    var result = [];
    var char = 0;
    var inMultiLineComment = false;
    var inLineComment = false;
    var inString = false;
    var currentCommentType = 'none';
    var escaping = false;
    var inVariable = false;
    var currentVariable = '';

    function addVariable(variable) {
        if (result.indexOf(variable) === -1) {
            result.push(variable);
        }
    }

    function isValidVariableChar(charecter) {
        if (charecter >= 'a' && charecter <= 'z') return true;
        if (charecter >= 'A' && charecter <= 'Z') return true;
        if (charecter >= '0' && charecter <= '9') return true;
        return charecter === '_';
    }

    while (char < text.length) {
        escaping = false;
        if (text[char] === '\\') {
            escaping = true;
            char += 2;
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
                    if (text.substring(char, char + 2) === "*/") {
                        inMultiLineComment = false;
                        char += 2;
                        continue
                    }
                    if (text[char] === '#') {
                        inLineComment = true;
                    }

                    if (text.substring(char, char + 2) === "/*") {
                        inMultiLineComment = true;
                        char += 2;
                        continue
                    }
                    if (text.substring(char, char + 2) === "//") {
                        inLineComment = true;
                        char += 2;
                        continue
                    }
                }
                if (!inMultiLineComment && !inLineComment) {
                    if (text[char] === '"' || text[char] === "'") {
                        if (currentCommentType === 'none') {
                            currentCommentType = text[char];
                            inString = true;
                        }
                        else if (inString && currentCommentType === text[char]) {
                            inString = false;
                            currentCommentType = 'none';
                        }
                    }
                    if (text[char] === '$') {
                        inVariable = true;
                    }
                    else if (inVariable) {
                        if (isValidVariableChar(text[char])) {
                            currentVariable += text[char]
                        }
                        else {
                            inVariable = false;
                            addVariable(currentVariable);
                            currentVariable = '';
                        }
                    }
                }
            }
            if (text[char] === '\n') {
                inLineComment = false;
                inString = false;
            }
        }
        char++;
    }
    return result.length > 0 ? result.length + ('\n') + result.join('\n') : '0';
}