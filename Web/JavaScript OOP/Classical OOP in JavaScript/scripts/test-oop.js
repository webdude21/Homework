function testOOP() {
    jsConsole.writeLine('---- amphibian tests ----');
    var amphibianTest = new vehicleModule.AmphibiousVehicle();
    amphibianTest.accelerate();
    jsConsole.writeLine('Amphibian speed:' + amphibianTest.speed + ' in land mode');

    amphibianTest.toggleLandWaterMode();
    jsConsole.writeLine('Amphibian speed: ' + amphibianTest.speed +
        ' after switching to another mode');
    amphibianTest.accelerate();
    jsConsole.writeLine('Amphibian speed: ' + amphibianTest.speed + ' in water mode');

    jsConsole.writeLine('---- aircraft tests ----');
    var aircraftTest = new vehicleModule.AirVehicle();
    aircraftTest.accelerate();
    jsConsole.writeLine('AirVehicle speed: ' + aircraftTest.speed + ' without afterburner');
    aircraftTest.speed = 0;

    aircraftTest.engageAfterburner();
    aircraftTest.accelerate();
    jsConsole.writeLine('AirVehicle speed: ' + aircraftTest.speed + ' with afterburner engaged');
}

function testCanvas() {
    var advancedCanvas = new AdvancedCanvas('the-canvas');
    advancedCanvas.drawLine(25, 25, 100, 100, 'yellow', 10);
    advancedCanvas.drawCircle(250, 250, 50, 'grey', 5);
    advancedCanvas.drawRect(150, 150, 50, 50, 'red', 9, 'blue');
}