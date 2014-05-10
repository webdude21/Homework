function Solver(params) {
    var variables = {
        V: 0,
        W: 0,
        X: 0,
        Y: 0,
        Z: 0};
    var output = '';
    var codeByLines = readInput();
    var stopFound = false;

    for (var currentLine = 0; currentLine < codeByLines.length; currentLine += 1) {
        if (stopFound) {
            return output;
        }
        if (codeByLines[currentLine]) {
            manageLine(codeByLines[currentLine])
        }
    }

    function readInput() {
        var code = [];
        for (var inputLine = 0; inputLine < params.length; inputLine += 1) {
            var lineNumber = parseInt(params[inputLine]);
            code[lineNumber] =
                params[inputLine].slice(lineNumber.toString().length).trim().replace(/\s+/g, '');
        }
        return code;
    }

    function getValue(stringInput) {
        return isNaN(parseInt(stringInput)) ? variables[stringInput[0]] : parseInt(stringInput);
    }

    function assignment(str) {
        var resultVar = str[0];
        var stringInput = str.slice(2);
        var firstNumber;

        if (isNaN(parseInt(stringInput))) {
            firstNumber = variables[stringInput[0]];
            stringInput = stringInput.slice(1);
        }
        else {
            firstNumber = parseInt(stringInput);
            stringInput = stringInput.slice(firstNumber.toString().length);
        }

        var operation = stringInput[0];
        stringInput = stringInput.slice(1);

        if (operation === '+') {
            variables[resultVar] = firstNumber + getValue(stringInput);
        }
        else if (operation === '-') {
            variables[resultVar] = firstNumber - getValue(stringInput);
        }
        else {
            variables[resultVar] = firstNumber;
        }
    }

    function condition(str) {
        var currentVar = str[2];
        var lineInputArr = str.slice(3);
        var boolResult = false;

        if (lineInputArr.indexOf('>=') === 0) {
            lineInputArr = lineInputArr.slice(2);
            if (variables[currentVar] >= getValue(lineInputArr)) {
                boolResult = true;
            }
        }
        else if (lineInputArr.indexOf('<=') === 0) {
            lineInputArr = lineInputArr.slice(2);
            if (variables[currentVar] <= getValue(lineInputArr)) {
                boolResult = true;
            }
        }
        else if (lineInputArr.indexOf('<') === 0) {
            lineInputArr = lineInputArr.slice(1);
            if (variables[currentVar] < getValue(lineInputArr)) {
                boolResult = true;
            }
        }
        else if (lineInputArr.indexOf('>') === 0) {
            lineInputArr = lineInputArr.slice(1);
            if (variables[currentVar] > getValue(lineInputArr)) {
                boolResult = true;
            }
        }
        else if (lineInputArr.indexOf('=') === 0) {
            lineInputArr = lineInputArr.slice(1);
            if (variables[currentVar] === getValue(lineInputArr)) {
                boolResult = true;
            }
        }

        if (boolResult) {
            var splitByThen = lineInputArr.split('THEN');
            manageLine(splitByThen[1]);
        }
    }

    function manageLine(lineInput) {
        if (lineInput.indexOf('IF') === 0) {
            condition(lineInput);
        }
        else if (lineInput.indexOf('PRINT') === 0) {
            output = output + variables[lineInput.slice(5)] + '\r\n';
        }
        else if (lineInput.indexOf('CLS') === 0) {
            output = '';
        }
        else if (lineInput.indexOf('GOTO') === 0) {
            currentLine = parseInt(lineInput.split('GOTO').pop()) - 1;
        }
        else if (lineInput.indexOf('STOP') === 0) {
            stopFound = true;
        }
        else {
            assignment(lineInput);
        }
    }

    return output;
}