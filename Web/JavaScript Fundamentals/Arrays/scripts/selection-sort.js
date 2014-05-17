function selectionSort(numberArray) {
    var sortedArray = new Array(numberArray.length);
    var current;

    for (var i = 0; i < sortedArray.length; i++) {
        current = findMin(numberArray);
        sortedArray[i] = numberArray[current];
        numberArray.splice(current, 1);
    }
    return sortedArray;
}

function findMin(numberArray) {
    var minIndex = 0;
    for (var j = 1; j < numberArray.length; j++)
        if (numberArray[j] < numberArray[minIndex])
            minIndex = j;
    return minIndex;
}