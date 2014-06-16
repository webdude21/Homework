(function () {
    if (!String.prototype.contains) {
        String.prototype.contains = function (searchPattern) {
            return this.indexOf(searchPattern) > -1;
        };
    }

    if (!Element.prototype.addClassName) {
        Element.prototype.addClassName = function (name) {
            if (!this.hasClassName(name)) {
                this.className = this.className ? [this.className, name].join(' ') : name;
            }
        };
    }

    if (!Element.prototype.removeClassName) {
        Element.prototype.removeClassName = function (name) {
            if (this.hasClassName(name)) {
                var c = this.className;
                this.className = c.replace(new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)", "g"), "");
            }
        };
    }

    if (!Element.prototype.hasClassName) {
        Element.prototype.hasClassName = function (name) {
            return new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)").test(this.className);
        };
    }

    if (!Array.prototype.unset) {
        Array.prototype.unset = function (value) {
            if (this.indexOf(value) !== -1) {
                this.splice(this.indexOf(value), 1);
            }
        };
    }

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

    if (!String.prototype.trimLeft) {
        String.prototype.trimLeft = function () {
            return (this + '$%&').trim().slice(0, -3);
        };
    }
    if (!String.prototype.trimRight) {
        String.prototype.trimRight = function () {
            return ('$%&' + this).trim().slice(0, -3);
        };
    }

    if (!String.prototype.trimLeftChars) {
        String.prototype.trimLeftChars = function (chars) {
            var regEx = new RegExp('^[' + chars + ']+');
            return this.replace(regEx, '');
        };
    }


    if (!String.prototype.trimLeftChars) {
        String.prototype.trimLeftChars = function (chars) {
            var regEx = new RegExp('^[' + chars + ']+');
            return this.replace(regEx, '');
        };
    }

    if (!String.prototype.replaceAll) {
        String.prototype.replaceAll = function (textToReplace, replacement) {
            var output = this;
            while (output.indexOf(textToReplace) > -1) {
                output = output.replace(textToReplace, replacement);
            }
            return output;
        };
    }

    if (!String.prototype.trimRightChars) {
        String.prototype.trimRightChars = function (chars) {

            var regEx = new RegExp('[' + chars + ']+$');
            return this.replace(regEx, '');
        };
    }

    if (!String.prototype.isNullOrEmpty) {
        String.prototype.isNullOrEmpty = function () {
            if (this === '' || this === null || this.trim() === '') {
                return true;
            }
        };
    }

    function multiplyString(str, timesToMultiply) {
        var strOut = '';
        for (var times = 0; times < timesToMultiply; times++) {
            strOut += str;
        }
        return strOut;
    }


    if (!String.prototype.trimChars) {
        String.prototype.trimChars = function (chars) {
            return this.trimLeftChars(chars).trimRightChars(chars);
        };
    }

    if (!String.prototype.padLeft) {
        String.prototype.padLeft = function (count, char) {
            char = char || ' ';
            if (char.length > 1) {
                return String(this);
            }
            if (this.length >= count) {
                return String(this);
            }
            var str = String(this);
            for (var i = 0, thisLen = str.length; i < count - thisLen; i++) {
                str = char + str;
            }
            return str;
        };
    }

    if (!String.prototype.padRight) {
        String.prototype.padRight = function (count, char) {
            char = char || ' ';
            if (char.length > 1) {
                return String(this);
            }
            if (this.length >= count) {
                return String(this);
            }
            var str = String(this);
            for (var i = 0, thisLen = this.length; i < count - thisLen; i++) {
                str += char;
            }
            return str;
        };
    }
})();



