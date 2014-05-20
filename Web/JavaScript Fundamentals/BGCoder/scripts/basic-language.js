function solve(input) {
    var output = '';
    var code = '';
    var buffer = '';

    for (var index = 0; index < input.length; index++) {
        code += input[index] + '\n';
        if (input[index].indexOf('EXIT') > -1) {
            break;
        }
    }
    input = [];

    for (index = 0; index < code.length; index++) {
        buffer += code[index];
        if (code[index] === ';') {
            input.push(buffer);
            buffer = '';
        }
    }

    for (var i = 0; i < input.length; i++) {
        execute(input[i]);
    }

    function loop(statement, cycles) {
        var currentStatement = statement.split(')')[0];
        var restOfStatement = statement.slice(currentStatement.length + 1).trim();
        currentStatement = currentStatement.replace('FOR', '').trim().slice(1);
        var a = parseInt(currentStatement);
        var additionalCycles;
        if (currentStatement.indexOf(',') > -1) {
            var b = parseInt(currentStatement.split(',')[1]);
        }
        additionalCycles = b !== undefined ? b - a + 1 : a;

        if (cycles !== undefined) {
            additionalCycles *= cycles;
        }
        execute(restOfStatement, additionalCycles);
    }

    function print(statement, cycles) {
        var currentStatement = statement.split(')')[0];
        currentStatement += ')';
        currentStatement = currentStatement.replace('PRINT', '').trim().slice(1, -1);
        var loops = cycles || 1;
        for (var i = 0; i < loops; i++) {
            output += currentStatement;
        }
    }

    function execute(statement, cycles) {
        statement = statement.trim();
        if (statement.indexOf('FOR') === 0) {
            loop(statement, cycles);
        } else if (statement.indexOf('PRINT') === 0) {
            print(statement, cycles);
        }
    }
    return output;
}