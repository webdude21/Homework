function binarySearch(keyNumber, array) {
    var indexWhereFound = -1;
    var right = array.length;
    var left = 0;
    var middle;

    for (var currentIndex = left; currentIndex < right; currentIndex++) {
        middle = parseInt((right + left) / 2);
        if (array[currentIndex] === keyNumber) {
            indexWhereFound = currentIndex;
            break;
        }
        if (keyNumber > array[middle]) {
            left = middle;
            currentIndex = middle;
        } else if (keyNumber < array[middle]) {
            right = middle;
        }

    }
    return indexWhereFound;
}