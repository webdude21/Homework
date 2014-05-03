// Write a function that formats a string using placeholders:

function stringFormat(str) {
    var strFormatArgs = arguments;

    var formatReplacer = function(match, p1) {
        return strFormatArgs[parseInt(p1) + 1] || match;
    };

    return str.replace(/{(\d+)\}/g, formatReplacer);
}