function familyTree(familyJSON) {
    var stage = setStage();
    var layer = setLayer();
    var persons = parsePersons(familyJSON);
    var root = findRoot(persons);

    function setStage() {
        return new Kinetic.Stage({
            container: 'kinetic-container',
            width: 1920,
            height: 1080
        });
    }

    function setLayer() {
        return new Kinetic.Layer({
            draggable: true
        });
    }

    function Person(name) {
        this.name = name;
        this.children = [];
        this.hasOffspring = function () {
            if (this.children.length > 0) {
                return true;
            }
        };
        this.hasParents = function () {
            if (this.father || this.mother) {
                return true;
            }
        };
        this.isFemale = false;
    }

    function addPersonIfNew(name, persons) {
        for (var i = 0; i < persons.length; i++) {
            if (persons[i].name === name) {
                return persons[i];
            }
        }

        var newPerson = new Person(name);
        persons.push(newPerson);
        return newPerson;
    }

    function parsePersons(familyJSON) {
        var persons = [];

        for (var i = 0; i < familyJSON.length; i++) {
            var obj = familyJSON[i];
            var mother = addPersonIfNew(obj.mother, persons);
            var father = addPersonIfNew(obj.father, persons);
            mother.spouse = father;
            mother.isFemale = true;
            father.spouse = mother;

            for (var j = 0; j < obj.children.length; j++) {
                var child = addPersonIfNew(obj.children[j], persons);
                mother.children.push(child);
                father.children.push(child);
                child.father = father;
                child.mother = mother;
            }
        }

        return persons;
    }

    function findRoot(persons) {
        for (var i = 0; i < persons.length; i++) {
            if (!persons[i].hasParents() && !persons[i].spouse.hasParents()) {
                return persons[i];
            }
        }
    }

    function findMinXCoordinate(persons) {
        var currentMin = Number.MAX_VALUE;
        for (var i = 0; i < persons.length; i++) {
            if (persons[i].x && persons[i].x < currentMin) {
                currentMin = persons[i].x;
            }
        }
        return currentMin;
    }

    var nodeWidth = 130;
    var nodeHeight = 30;
    var fontSize = 12;
    var strokeColor = '#77B300';
    var textPadding = 10;
    var textColor = 'black';
    var widthSpace = nodeWidth + 20;
    var heightSpace = nodeHeight + 40;

    var drawer = new Drawer(layer, nodeWidth, nodeHeight, fontSize, strokeColor, textPadding, textColor);
    drawTree(root, drawer, 10, 10, true);
    layer.offsetX(findMinXCoordinate(persons));
    stage.add(layer);

    function drawTree(currentNode, drawer, startX, startY) {
        var x = startX;
        var y = startY;

        if (currentNode.spouse) {
            drawer.drawPerson(currentNode.spouse, x, y);
            x += widthSpace;
        }
        drawer.drawPerson(currentNode, x, y);

        x = startX;

        for (var i = 0; i < currentNode.children.length; i++) {
            if (i && currentNode.children[i - 1].spouse) {
                x += widthSpace;
            }
            drawTree(currentNode.children[i], drawer, x - widthSpace, y + heightSpace);
            x += widthSpace;
        }
    }
}