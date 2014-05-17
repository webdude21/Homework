function solve(input) {
    var terrain = input[0].split(', ');
    var maxVisited = 0;
    var terrainLength = terrain.length;

    for (var i = 0; i < terrainLength; i++) {
        terrain[i] = terrain[i] | 0;
    }

    for (var jumpSize = 1; jumpSize < terrainLength; jumpSize++) {
        for (var startPos = 1; startPos < terrainLength; startPos++) {
            var currentMax = 1;
            var position = startPos;

            var nextStep = position + jumpSize >= terrainLength ?
                position + jumpSize - terrainLength : position + jumpSize;

            while (terrain[position] < terrain[nextStep]) {
                currentMax += 1;
                position = nextStep;

                nextStep = position + jumpSize >= terrainLength ?
                    position + jumpSize - terrainLength : position + jumpSize;
            }

            if (currentMax > maxVisited) {
                maxVisited = currentMax;
            }
        }
    }
    return maxVisited;
}