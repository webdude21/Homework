function generateTagFromUserInput() {
    var tags = document.getElementById('ta-cloudInput').value.split(',');
    var minTextSize = document.getElementById('ib-minFontSize').value | 0;
    var maxTextSize = document.getElementById('ib-maxFontSize').value | 0;
    var tagCloud = generateTagCloud(tags, minTextSize, maxTextSize);
    tagCloud.style.width = '250px';
    tagCloud.style.overflow = 'overlay';
    tagCloud.style.border = '1px solid black';
    tagCloud.style.padding = '10px';
    tagCloud.style.textAlign = 'justify';
    document.body.appendChild(tagCloud);
}

function findOccurrenceAmplitude(tagsOccurrences) {
    var min = Infinity;
    var max = -Infinity;
    var itemValue;

    for (var item in tagsOccurrences) {
        if (tagsOccurrences.hasOwnProperty(item)) {
            itemValue = tagsOccurrences[item];
            if (itemValue < min) {
                min = itemValue;
            }
            if (itemValue > max) {
                max = itemValue;
            }
        }
    }
    return max - min;
}

function generateTagCloud(tags, minSize, maxSize) {
    var div = document.createElement('div');
    var tagsOccurrences = [];

    var addToListWithOccurrences = function (item) {
        if (tagsOccurrences[item]) {
            tagsOccurrences[item]++;
        } else {
            tagsOccurrences[item] = 1;
        }
    };
    tags.forEach(addToListWithOccurrences);
    var occurrencesAmplitude = findOccurrenceAmplitude(tagsOccurrences);
    var fontSizeStep = (maxSize - minSize) / (occurrencesAmplitude);
    var span = document.createElement('span');

    for (var tag in tagsOccurrences) {
        if (tagsOccurrences.hasOwnProperty(tag)) {
            var newItem = span.cloneNode(true);
            newItem.textContent = tag.trim() + ' ';
            newItem.style.fontSize = ((tagsOccurrences[tag] * fontSizeStep) + (minSize - fontSizeStep)) + 'px';
            div.appendChild(newItem);
        }
    }
    return div;
}