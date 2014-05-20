function solve(inputArr) {
    var funcList = {};

    String.prototype.splitByComma = function splitByComma() {
        return this.trim().split(/\s*,\s*/gi);
    };
    String.prototype.splitByWhiteSpace = function splitByWhiteSpace() {
        return this.trim().split(/\s+/gi);
    };
    String.prototype.extractExpression = function extractExpression() {
        return this.match(/\[[^]*\]/gi)[0].slice(1, -1);
    };

    for (var index = 0; index < inputArr.length - 1; index++) {

        if (inputArr[index].slice(0, 3) === 'def') {
            var currentCmdLine = inputArr[index].splitByWhiteSpace();
            var currentExpression = inputArr[index].extractExpression();
            var currentOperation = currentCmdLine[2].slice(0, 3);

            if (currentOperation.indexOf(',') > -1 || currentOperation.indexOf('[') > -1) {
                funcList[currentCmdLine[1]] = currentExpression;
            } else {
                funcList[currentCmdLine[1]] = solveExpression(currentExpression, currentOperation);
            }
        }
    }

    var lastIndex = inputArr.length - 1;

    if (inputArr[lastIndex].slice(0, 3).indexOf('[') > -1) {
        return funcList[inputArr[lastIndex].slice(1, -1)];
    }else {
        return solveExpression(inputArr[lastIndex].extractExpression(), inputArr[lastIndex].slice(0, 3));
    }

    function solveExpression(expressionString, operation) {
        var operands = expressionString.splitByComma();

        switch (operation) {
            case 'sum':
                return sum(operands);
            case 'min':
                return min(operands);
            case 'max':
                return max(operands);
            case 'avg':
                return parseInt(sum(operands) / operands.length, 10);
        }

        function getNumberValue(str) {
            if (funcList[str] !== undefined) {
                var variable = funcList[str];
                if (isNaN(variable) && variable.indexOf(',') >= 0) {
                    return solveExpression(variable, operation);
                }
                return variable;
            } else {
                return parseInt(str);
            }
        }

        function sum(operandColection) {
            var currentSum = 0;
            operandColection.forEach(function (obj) {
                currentSum += getNumberValue(obj);
            });
            return currentSum;
        }

        function min(operandColection) {
            var minValue = Number.MAX_VALUE;
            for (var i = 0; i < operandColection.length; i++) {
                if (getNumberValue(operandColection[i]) < minValue) {
                    minValue = getNumberValue(operandColection[i]);
                }
            }
            return minValue;
        }

        function max(operandColection) {
            var maxValue = -Number.MAX_VALUE;
            for (var i = 0; i < operandColection.length; i++) {
                if (getNumberValue(operandColection[i]) > maxValue) {
                    maxValue = getNumberValue(operandColection[i]);
                }
            }
            return maxValue;
        }
    }
}