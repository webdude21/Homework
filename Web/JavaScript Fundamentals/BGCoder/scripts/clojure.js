function Solve(inputArr) {
    var funcList = {};
    var clojureMatch = /(\([^()]*\))/gi;
    var dividingByZero = false;

    String.prototype.deleteBrackets = function() {
        return this.slice(1, -1);
    };

    String.prototype.splitByWhiteSpace = function() {
        return this.trim().split(/\s+/gi);
    };

    function getNumberValue(str) {
        return isNaN(parseInt(str)) ? funcList[str] : parseInt(str);
    }

    function mathOperation(argArray) {
        var operation = argArray[0];
        var resultVariable = getNumberValue(argArray[1]);
        var operands = argArray.slice(2);

        switch (operation) {
            case '+':
                operands.forEach(function (obj) { resultVariable += getNumberValue(obj); });
                break;
            case '-':
                operands.forEach(function (obj) { resultVariable -= getNumberValue(obj); });
                break;
            case '*':
                operands.forEach(function (obj) { resultVariable *= getNumberValue(obj); });
                break;
            case '/':
                operands.forEach(function (obj) { resultVariable /= getNumberValue(obj); });
                break;
        }

        dividingByZero = (resultVariable === Infinity);
        return parseInt(resultVariable, 10);
    }

    for (var currentLine = 0; currentLine < inputArr.length; currentLine++) {

        var currentCommand = inputArr[currentLine].deleteBrackets();
        var clojure = currentCommand.match(clojureMatch);

        if (clojure) {
            clojure = clojure[0].toString();
            currentCommand = currentCommand.replace(clojure, '');
            clojure = clojure.deleteBrackets();
        }

        var cmdArray = currentCommand.splitByWhiteSpace();

        if (cmdArray[0] === 'def') {
            var variableName = cmdArray[1];
            if (clojure) {
                funcList[variableName] = mathOperation(clojure.splitByWhiteSpace());
            } else {
                funcList[variableName] = getNumberValue(cmdArray[2]);
            }
        } else {
            return mathOperation(cmdArray);
        }
        if (dividingByZero) {
            return "Division by zero! At Line:" + (currentLine + 1);
        }
    }
}