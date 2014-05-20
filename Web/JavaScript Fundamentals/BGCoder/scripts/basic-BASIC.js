function solve(input) {
    var variables = { V: 0, W: 0, X: 0, Y: 0, Z: 0 };
    var output = '';
    var stopFound = false;
    var code = [];

    for (var index = 0; index < input.length; index += 1) {
        var lineNumber = parseInt(input[index]);
        code[lineNumber] =
            input[index].slice(lineNumber.toString().length).trim().replace(/\s+/g, '');
    }

    for (var line = 0; line < code.length; line += 1) {
        if (stopFound) {
            break;
        }
        if (code[line]) {
            execute(code[line]);
        }
    }

    function getValueFromStr(str) {
        return isNaN(parseInt(str)) ? variables[str[0]] : parseInt(str);
    }

    function assignment(str) {
        var resultVar = str[0];
        var stringInput = str.slice(2);
        var firstNumber;

        if (isNaN(parseInt(stringInput))) {
            firstNumber = variables[stringInput[0]];
            stringInput = stringInput.slice(1);
        } else {
            firstNumber = parseInt(stringInput);
            stringInput = stringInput.slice(firstNumber.toString().length);
        }

        var operation = stringInput[0];
        stringInput = stringInput.slice(1);

        if (operation === '+') {
            variables[resultVar] = firstNumber + getValueFromStr(stringInput);
        } else if (operation === '-') {
            variables[resultVar] = firstNumber - getValueFromStr(stringInput);
        } else {
            variables[resultVar] = firstNumber;
        }
    }

    function condition(str) {
        var firstVariable = str[2];
        var secondVariable = getValueFromStr(str.slice(4));
        var boolResult;

        switch (str.slice(3, 4)) {
            case '<':
                boolResult = variables[firstVariable] < secondVariable;
                break;
            case '>':
                boolResult = variables[firstVariable] > secondVariable;
                break;
            case '=':
                boolResult = variables[firstVariable] === secondVariable;
        }

        if (boolResult) {
            execute(str.split('THEN')[1]);
        }
    }

    function execute(statement) {
        if (statement.indexOf('IF') === 0) {
            condition(statement);
        } else if (statement.indexOf('PRINT') === 0) {
            output = output + variables[statement.slice(5)] + '\r\n';
        } else if (statement.indexOf('CLS') === 0) {
            output = '';
        } else if (statement.indexOf('GOTO') === 0) {
            line = parseInt(statement.split('GOTO').pop()) - 1;
        } else if (statement.indexOf('STOP') === 0) {
            stopFound = true;
        } else {
            assignment(statement);
        }
    }

    return output;
}