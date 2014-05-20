function solve(input) {
    input.shift();
    var text = input.join('\n');
    var currentMatches;

    var tagReplacer = function(match, tag, tagContent) {
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

        function toggleString() {
            var strToggled = '';
            for (var index = 0; index < tagContent.length; index++) {
                strToggled += tagContent[index] === tagContent[index].toUpperCase() ?
                    tagContent[index].toLowerCase() : tagContent[index].toUpperCase();
            }
            return strToggled;
        }
    };

    do {
        currentMatches = text.match(/<([^>]+)>([^<]*)<\/\1>/i);
        text = text.replace(/<([^>]+)>([^<]*)<\/\1>/i, tagReplacer);
    }
    while (currentMatches);

    return text;
}