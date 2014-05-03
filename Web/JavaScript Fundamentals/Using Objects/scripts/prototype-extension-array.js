/* Write a function that removes all elements with a given value
 * Attach it to the array type
 * Read about prototype and how to attach methods  */
function run() {
    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
    jsConsole.writeLine("The initial array: " + arr);
    arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];
    jsConsole.writeLine("The array with the number 1 removed: " + arr);
}

Array.prototype.remove = function (number) {
    for (var i = 0; i < this.length; i++) {
        if (number === this[i]) {
            this.splice(i, 1);
        }
    }
};

