var specialConsole = (function () {
    function stringFormat() {
        var strFormatArgs = arguments[0];
        var mainString = strFormatArgs[0];

        var formatReplacer = function (match, p1) {
            return strFormatArgs[parseInt(p1) + 1].toString() || match;
        };

        return mainString.replace(/{(\d+)\}/g, formatReplacer);
    }

    return {
        writeLine: function () {
            console.log(stringFormat(arguments))
        },
        writeError: function () {
            console.error(stringFormat(arguments))
        },
        writeWarning: function () {
            console.warn(stringFormat(arguments))
        }
    }
}());