function testDomModule() {
    var div = document.createElement("div");

    //appends div to #wrapper
    domModule.appendChild(div, "#wrapper");

    //removes li:first-child from ul
    domModule.removeChild("ul", "li:first-child");

    //add handler to each a element with class button
    domModule.addHandler("a.button", 'click',
        function () {
            alert("Clicked")
        });

    domModule.appendToBuffer("container", div.cloneNode(true));
}

function testMovingShapes() {
    movingShapes.add('rect');
    movingShapes.add('ellipse');
}

function testSpecialConsole() {

    specialConsole.writeLine("Message: hello");
    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: {0}", "hello");
    //logs to the console "Message: hello"
    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");

}