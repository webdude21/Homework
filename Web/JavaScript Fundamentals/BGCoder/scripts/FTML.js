function Solver(inputArr) {
    inputArr.shift();
    var input = '';
    var currentMatches;

    for (var i = 0; i < inputArr.length; i++) {
        input += inputArr[i];
        if (i < inputArr.length - 1) {
            input += ('\r\n');
        }
    }

    var tagReplacer = function tagReplacer(match, tag, tagContent) {
        switch (tag.toLowerCase()) {
            case 'lower':
                return tagContent.toLowerCase();
            case 'upper':
                return tagContent.toUpperCase();
            case 'toggle':
                return toggleString(tagContent);
            case 'del':
                return '';
            case 'rev':
                return reverseString(tagContent);
        }
    };

    do {
        currentMatches = input.match(/<([^>]+)>([^<]*)<\/\1>/i);
        input = input.replace(/<([^>]+)>([^<]*)<\/\1>/i, tagReplacer);
    }
    while (currentMatches);

    function toggleString(tagContent) {
        var strToggled = '';
        for (var index = 0; index < tagContent.length; index++) {
            strToggled += tagContent[index] === tagContent[index].toUpperCase() ?
                tagContent[index].toLowerCase() : tagContent[index].toUpperCase();
        }
        return strToggled;
    }

    function reverseString(tagContent) {
        var strOutput = '';
        var strReversed = tagContent.split('\r\n');
        for (var index = strReversed.length - 1; index >= 0; index--) {
            for (var chr = strReversed[index].length - 1; chr >= 0; chr--) {
                strOutput += strReversed[index][chr];
            }
            if (index > 0) {
                strOutput += ('\r\n');
            }
        }
        return strOutput;
    }
    return input;
}