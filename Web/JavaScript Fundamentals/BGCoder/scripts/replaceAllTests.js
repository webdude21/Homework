function solve(input) {
    var result = input.join("\n");

    if (!String.prototype.reduceWhiteSpace) {
        String.prototype.reduceWhiteSpace = function () {
            var output = '';
            var char = 0;
            var inWhiteSpace = true;
            while (char < this.length) {
                if (this[char] === ' ' || this[char] === '\t') {
                    if (!inWhiteSpace) {
                        inWhiteSpace = true;
                        output += this[char];
                    }
                } else {
                    inWhiteSpace = false;
                    output += this[char];
                }
                char++;
            }
            return output;
        }
    }

    return result.reduceWhiteSpace();
}