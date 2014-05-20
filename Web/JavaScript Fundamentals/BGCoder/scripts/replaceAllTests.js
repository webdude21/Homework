function solve(input) {
    var result = input.join("\n");

    if (!String.prototype.reduceWhiteSpace) {
        String.prototype.reduceWhiteSpace = function () {
            var output = '';
            var chr = 0;
            var inWhiteSpace = true;
            while (chr < this.length) {
                if (this[chr] === ' ' || this[chr] === '\t') {
                    if (!inWhiteSpace) {
                        inWhiteSpace = true;
                        output += this[chr];
                    }
                } else {
                    inWhiteSpace = false;
                    output += this[chr];
                }
                chr++;
            }
            return output;
        };
    }

    return result.reduceWhiteSpace();
}