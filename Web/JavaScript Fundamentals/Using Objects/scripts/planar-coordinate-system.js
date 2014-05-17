/* Write functions for working with shapes in  standard Planar coordinate system
 Points are represented by coordinates P(X, Y)
 Lines are represented by two points, marking their beginning and ending
 L(P1(X1,Y1), P2(X2,Y2))
 Calculate the distance between two points
 Check if three segment lines can form a triangle     */

function run() {
    var point1 = new Point(1, 3);
    var point2 = new Point(3, 10);

    var a = new Line(new Point(1, 2), new Point(3, 4));
    var b = new Line(new Point(1, 4), new Point(3, 4));
    var c = new Line(new Point(1, 3), new Point(3, 4));

    jsConsole.writeLine("The distance between " + point1 + " and " +
        point2 + " is: " + calcDistanceBetweenTwoPoints(point1, point2));
    jsConsole.writeLine("The lines:");
    jsConsole.writeLine(a);
    jsConsole.writeLine(b);
    jsConsole.writeLine(c);

    if (checkIfThreeLinesCanFormTriangle(a, b, c)) {
        jsConsole.writeLine("Can form a triangle");
    }
    else {
        jsConsole.writeLine("Cannot form a triangle");
    }
}

function calcDistanceBetweenTwoPoints(a, b) {
    return new Line(a, b).getLength();
}

function checkIfThreeLinesCanFormTriangle(a, b, c) {
    return (a.getLength() < b.getLength() + c.getLength()) &&
        (b.getLength() < a.getLength() + c.getLength()) &&
        (c.getLength() < a.getLength() + b.getLength());
}

function Point(x, y) {
    if (!isNaN(x) && !isNaN(y)) {
        var that = this;
        this.X = x;
        this.Y = y;
        this.toString = function () {
            return '[' + that.X + ',' + that.Y + ']';
        };

        return that;
    }
}

function Line(startPoint, endPoint) {
    if (startPoint instanceof Point && endPoint instanceof Point) {
        var that = this;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.toString = function () {
            return "{" + that.startPoint.toString() + ' '
                + that.endPoint.toString() + "}";
        };
        this.getLength = function () {
            return Math.sqrt(Math.pow((endPoint.X - startPoint.X), 2) +
                Math.pow((endPoint.Y - startPoint.Y), 2));
        };

        return that;
    }
}