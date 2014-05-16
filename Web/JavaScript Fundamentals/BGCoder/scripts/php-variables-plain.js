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
        if (result.indexOf(variable) === -1 && variable !== '') {
            result.push(variable);
        }
    }

    function isValidVariableChar(character) {
        if (character >= 'a' && character <= 'z') return true;
        if (character >= 'A' && character <= 'Z') return true;
        if (character >= '0' && character <= '9') return true;
        return character === '_';
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
                        if (inVariable) {
                            addVariable(currentVariable);
                            currentVariable = '';
                        }
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
    result.sort();
    return result.length > 0 ? result.length + ('\n') + result.join('\n') : '0';
}