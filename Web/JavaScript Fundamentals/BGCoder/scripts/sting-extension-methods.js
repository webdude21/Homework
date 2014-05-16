(function () {
    if (!String.prototype.contains) {
        String.prototype.contains = function (searchPattern) {
            return this.indexOf(searchPattern) > -1;
        }
    }

    if (!String.prototype.trimLeft) {
        String.prototype.trimLeft = function () {
            return (this + '$%&').trim().slice(0, -3);
        }
    }
    if (!String.prototype.trimRight) {
        String.prototype.trimRight = function () {
            return ('$%&' + this).trim().slice(0, -3);
        }
    }

    if (!String.prototype.trimLeftChars) {
        String.prototype.trimLeftChars = function (chars) {
            var regEx = new RegExp('^[' + chars + ']+');
            return this.replace(regEx, '');
        }
    }

    if (!String.prototype.trimRightChars) {
        String.prototype.trimRightChars = function (chars) {

            var regEx = new RegExp('[' + chars + ']+$');
            return this.replace(regEx, '');
        }
    }

    if (!String.prototype.isNullOrEmpty) {
        String.prototype.isNullOrEmpty = function () {
            if (this === '' || this === null || this.trim() === '') {
                return true;
            }
        }
    }


    if (!String.prototype.trimChars) {
        String.prototype.trimChars = function (chars) {
            return this.trimLeftChars(chars).trimRightChars(chars);
        }
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
        }
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
        }
    }
})();