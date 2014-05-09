function Solve(inputArr) {
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
            var currentCMDLine = inputArr[index].splitByWhiteSpace();
            var currentExpression = inputArr[index].extractExpression();
            var operation = currentCMDLine[2].slice(0, 3);

            if (operation.indexOf(',') > -1 || operation.indexOf('[') > -1) {
                funcList[currentCMDLine[1]] = currentExpression;
            }
            else {
                funcList[currentCMDLine[1]] = solveExpression(currentExpression, operation);
            }
        }
    }

    var lastIndex = inputArr.length - 1;

    if (inputArr[lastIndex].slice(0, 3).indexOf('[') > -1) {
        return funcList[inputArr[lastIndex].slice(1, -1)];
    }
    else {
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
            }
            else {
                return parseInt(str);
            }
        }

        function sum(operands) {
            var sum = 0;
            operands.forEach(function (obj) {
                sum += getNumberValue(obj)
            });
            return sum;
        }

        function min(operands) {
            var min = Number.MAX_VALUE;
            for (var index = 0; index < operands.length; index++) {
                if (getNumberValue(operands[index]) < min) {
                    min = getNumberValue(operands[index]);
                }
            }
            return min;
        }

        function max(operands) {
            var max = -Number.MAX_VALUE;
            for (var index = 0; index < operands.length; index++) {
                if (getNumberValue(operands[index]) > max) {
                    max = getNumberValue(operands[index]);
                }
            }
            return max;
        }
    }
}