function Solver(inputArr) {
    inputArr.shift();
    var text = inputArr.join('\n');
    var currentMatches;

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
        currentMatches = text.match(/<([^>]+)>([^<]*)<\/\1>/i);
        text = text.replace(/<([^>]+)>([^<]*)<\/\1>/i, tagReplacer);
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
    return text;
}