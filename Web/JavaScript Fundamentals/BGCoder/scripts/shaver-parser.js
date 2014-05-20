function solve(input) {
    var definitionsLength = parseInt(input[0]);
    var definitions = {};
    var code = input.slice(definitionsLength + 2).join('\n');
    var index = 0;
    var sections = {};
    var sectionName = '';

    getDefinitions();
    function getDefinitions() {
        for (var i = 1; i <= definitionsLength; i++) {
            var currentDef = input[i].split(':');
            definitions[currentDef[0]] = parseValue(currentDef[1]);
        }
    }

    function getFromBrackets(str) {
        var out;
        out = str.split('("');
        out = out[1].split('")');
        return out[0];
    }

    function getFromCurlyBrackets(str) {
        var out;
        out = str.split('{');
        out = out[1].split('}');
        return out[0];
    }

    function parseValue(literal) {
        if (literal.trim() === 'true') {
            return true;
        }
        if (literal.trim() === 'false') {
            return false;
        }
        if (literal.indexOf(',') > -1) {
            return literal.split(',');
        }
        else {
            return literal;
        }
    }

    var chr;
    var result = '';
    var inCommand = false;
    var currentCommand = '';
    var inSectionDefinition = false;
    var nameDefined = false;

    while (index < code.length) {
        chr = code[index];

        if (inCommand) {
            if (inSectionDefinition && !nameDefined) {
                if (chr !== ' ' && chr !== '{') {
                    sectionName += chr;
                }
                else {
                    nameDefined = true;
                    index++;
                    continue;
                }

                if (nameDefined) {
                    if (chr === '}') {
                        inSectionDefinition = false;
                        nameDefined = false;
                        index++;
                        continue;
                    }
                    else {
                        sections[sectionName] += chr;
                    }
                }
            }

            if (chr !== ' ' && chr !== '<') {
                currentCommand += chr;
            }
            else {
                if (currentCommand === 'section') {
                    inSectionDefinition = true;
                    currentCommand = '';
                    index += 1;
                    continue;
                }
                if (!inSectionDefinition) {
                    inCommand = false;
                }
                if (currentCommand.indexOf('renderSection') > -1) {
                    result += sections[getFromBrackets(currentCommand)];
                }

                if (definitions[currentCommand]) {
                    result += definitions[currentCommand];
                }
                else {
                    result += currentCommand;
                }
                currentCommand = '';
            }
        }

        if (!inCommand) {
            if (chr === '@' && code[index + 1] === '@') {
                index += 2;
                result += chr;
                continue;
            }
            else if (chr === '@') {
                inCommand = true;
                index += 1;
                continue;
            }
            result += chr;
        }
        index++;
    }

    return result;
}