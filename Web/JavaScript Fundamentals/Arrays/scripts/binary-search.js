function binarySearch(key, array) {
    var indexWhereFound = -1;
    var right = array.length;
    var left = 0;
    var middle;

    for (var currentIndex = left; currentIndex < right; currentIndex++) {
        middle = parseInt((right + left) / 2);
        if (array[currentIndex] === key) {
            indexWhereFound = currentIndex;
            break;
        }
        if (key > array[middle]) {
            left = middle;
            currentIndex = middle;
        } else if (key < array[middle]) {
            right = middle;
        }
    }
    return indexWhereFound;
}