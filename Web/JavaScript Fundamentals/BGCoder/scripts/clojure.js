function Solve(inputArr) {
    var funcList = {};
    var clojureMatch = /(\([^()]*\))/gi;
    var dividingByZero = false;

    String.prototype.removeBrackets = function removeBrackets() {
        return this.slice(1, -1);
    };
    String.prototype.splitByWhiteSpace = function splitByWhiteSpace() {
        return this.trim().split(/\s+/gi);
    };

    function getNumberValue(obj){
        return isNaN(parseInt(obj)) ? funcList[obj] : parseInt(obj);
    }

    function mathOperation(argArray) {
        var operation = argArray[0];
        var resultVariable = argArray[1]; // get first operand
        resultVariable = isNaN(resultVariable) ? funcList[resultVariable] : parseInt(resultVariable);
        var operands = argArray.slice(2);

        switch (operation) {
            case '+':
                operands.forEach(function (obj) {
                    resultVariable += getNumberValue(obj);
                });
                break;
            case '-':
                operands.forEach(function (obj) {
                    resultVariable -= getNumberValue(obj);
                });
                break;
            case '*':
                operands.forEach(function (obj) {
                    resultVariable *= getNumberValue(obj);
                });
                break;
            case '/':
                operands.forEach(function (obj) {
                    resultVariable /= getNumberValue(obj);
                });
                break;
        }
        if (resultVariable === Infinity) {
            dividingByZero = true;
        }
        return parseInt(resultVariable, 10);
    }

    for (var currentLine = 0; currentLine < inputArr.length; currentLine++) {

        var currentCommand = inputArr[currentLine].removeBrackets();
        var clojure = currentCommand.match(clojureMatch);

        if (clojure) {
            clojure = clojure[0].toString();
            currentCommand = currentCommand.replace(clojure, '');
            clojure = clojure.removeBrackets();
        }

        var cmdArray = currentCommand.splitByWhiteSpace();
        if (cmdArray[0] === 'def') {
            var variableName = cmdArray[1];
            if (clojure) {
                funcList[variableName] = mathOperation(clojure.splitByWhiteSpace());
            }
            else {
                funcList[variableName] = getNumberValue(cmdArray[2]);
            }
        }
        else {
            return mathOperation(cmdArray);
        }

        if (dividingByZero) {
            return "Division by zero! At Line:" + (currentLine + 1);
        }
    }
}