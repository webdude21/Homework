function solve(input) {
    input.shift();
    var text = input.join('\n');
    var result = [];
    var variableMatcher = /\$\w+/gim;
    var commentMatcher = /(?:\/\*(?:[\s\S]*?)\*\/)|(?:^\s*\/\/(?:.*)$)|(?:^\s*#(?:.*)$)/gim;
    text = text.replace(commentMatcher, '');
    var varMatches = text.match(variableMatcher);

    if (varMatches) {
        for (var i = 0; i < varMatches.length; i++) {
            if (result.indexOf(varMatches[i]) === -1) {
                result.push(varMatches[i]);
            }
        }
    }

    text = '' + result.length || 0;
    for (var index = 0; index < result.length; index++) {
        text += '\n' + result[index].slice(1);
    }

    return text;
}