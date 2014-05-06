/* Write a function that makes a deep copy of an object
 * The function should work for both primitive and reference types */

function deepCopyTest() {
    var testLine = new Line(new Point(1, 2), new Point(3, 4));

    var deepCopyOfTestLine = deepCopy(testLine);
    deepCopyOfTestLine.startPoint.Y = 19;
    console.log("");
    jsConsole.writeLine(testLine.startPoint.Y);
    jsConsole.writeLine(deepCopyOfTestLine.startPoint.Y);
}

function deepCopy(variable) {
    if (typeof variable !== 'object') {
        return variable;
    }
    var newObj = {};
    for (var item in variable) {
        newObj[item] = deepCopy(variable[item]);
    }
    return newObj;
}
