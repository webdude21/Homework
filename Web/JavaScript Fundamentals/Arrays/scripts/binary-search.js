function binarySearch(keyNumber, array) {
    var indexWhereFound = -1;
    var right = array.length;
    var left = 0;
    var middle = parseInt(right / 2);

    for (var currentIndex = left; currentIndex < right; currentIndex++) {
        middle = parseInt(right / 2);
        if (array[currentIndex] === keyNumber) {
            indexWhereFound = currentIndex;
            break;
        }
        if (keyNumber > middle)
            left = middle;
        else if (keyNumber < right)
            right = middle;
    }
    return indexWhereFound;
}
