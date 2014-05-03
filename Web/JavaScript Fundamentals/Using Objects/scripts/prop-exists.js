// Write a function that checks if a given object contains a given property

function testIfPropertyExists() {
    var obj = {};
    var property = document.getElementById('tb-prop').value;
    var hasProp = hasProperty(document, property);
    jsConsole.writeLine(hasProp.toString());
}

function hasProperty(obj, property){
    return obj[property] !== undefined;
}
