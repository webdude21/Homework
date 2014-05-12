function Solver(input) {
    var terrain = input[0].trim().split(', ');
    var maxVisited = 0;
    var terrainLength = terrain.length;

    for (var i = 0; i < terrainLength; i++) {
        terrain[i] = parseInt(terrain[i], 10);
    }

    for (var jumpSize = 1; jumpSize < terrainLength; jumpSize++) {
        for (var startPos = 0; startPos < terrainLength; startPos++) {
            var currentMax = 1;
            var position = startPos;
            var nextStep = getNextStep(position, jumpSize);

            while (terrain[position] < terrain[nextStep]) {
                currentMax++;
                position = nextStep;
                nextStep = getNextStep(position, jumpSize);
            }

            if (currentMax > maxVisited) {
                maxVisited = currentMax;
            }
        }
    }

    function getNextStep(currentPosition, jumpSize) {
        return currentPosition + jumpSize >= terrainLength ?
            currentPosition + jumpSize - terrainLength : currentPosition + jumpSize;
    }

    return maxVisited;
}