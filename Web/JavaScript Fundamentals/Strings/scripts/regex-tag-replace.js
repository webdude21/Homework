function replaceTags(inputText) {
    var  upCase = tagRegExpConstruct("upcase");
    var lowCase = tagRegExpConstruct("lowcase");
    var mixCase = tagRegExpConstruct("mixCase");

    inputText = inputText.replace(upCase, function (match, replacementText) {
        return replacementText.toUpperCase();
    });
    inputText = inputText.replace(lowCase, function (match, replacementText) {
        return replacementText.toLowerCase();
    });
    inputText = inputText.replace(mixCase, function (match, replacementText) {
        return replacementText.toMixCase();
    });

    return inputText;
}

String.prototype.toMixCase = function () {
    var charArray = this.split('');
    for (var index = 0; index < charArray.length; index++) {
        if (Math.random() > 0.5) {
            charArray[index] = charArray[index].toString().toLowerCase();
        } else {
            charArray[index] = charArray[index].toString().toUpperCase();
        }
    }
    return charArray.join("");
};

function tagRegExpConstruct(tag, caseSensitive) {
    var matchOptions = 'g';
    var tagText = '([^<]+)';
    var tagConstruct = "<" + tag + ">" + tagText + "</" + tag + ">";

    if (!caseSensitive) {
        matchOptions = matchOptions + 'i';
    }
    return new RegExp(tagConstruct, matchOptions);
}