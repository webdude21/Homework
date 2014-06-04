function Drawer(layer, nodeWidth, nodeHeight, fontSize, strokeColor, textPadding, textFillColor) {
    this.drawPerson = function (person, x, y) {
        function drawText() {
            return new Kinetic.Text({
                x: x,
                y: y,
                width: nodeWidth,
                padding: textPadding,
                text: person.name,
                fontSize: fontSize,
                fill: textFillColor,
                align: 'center'
            });
        }

        function drawRect() {
            var radius = 7;
            if (person.isFemale) {
                radius = 15;
            }

            person.x = x;
            person.y = y;

            return new Kinetic.Rect({
                x: x,
                y: y,
                width: nodeWidth,
                stroke: strokeColor,
                strokeWidth: 1,
                height: nodeHeight,
                cornerRadius: radius
            });
        }

        function connectToParent(parent, layer) {
            layer.add(new Kinetic.Line({
                points: [x + nodeWidth / 2, y,
                        parent.x + nodeWidth / 2, parent.y + nodeHeight],
                stroke: strokeColor,
                strokeWidth: 2,
                tension: 1
            }));
        }

        function connectToSpouse(person, layer) {
            layer.add(new Kinetic.Line({
                points: [x , y + (nodeHeight / 2),
                        person.x + nodeWidth, y + (nodeHeight / 2)],
                stroke: strokeColor,
                strokeWidth: 10
            }));
        }

        if (person.hasParents()) {
            if (person.mother) {
                connectToParent((person.mother), layer);
            }
            if (person.father) {
                connectToParent((person.father), layer);
            }
        }

        if (person.spouse) {
            connectToSpouse(person.spouse, layer);
        }

        layer.add(drawText());
        layer.add(drawRect());
    }
}