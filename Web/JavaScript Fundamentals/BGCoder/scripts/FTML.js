function Solver(inputArr) {
    inputArr.shift();
    var document = '';
    var currentMatches;

    for (var i = 0; i < inputArr.length; i++) {
        document += inputArr[i];
        if (i < inputArr.length - 1) {
            document += ('\n');
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
                return tagContent.split('').reverse().join('');
        }
    };

    do {
        currentMatches = document.match(/<([^>]+)>([^<]*)<\/\1>/i);
        document = document.replace(/<([^>]+)>([^<]*)<\/\1>/i, tagReplacer);
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

    return document;
}