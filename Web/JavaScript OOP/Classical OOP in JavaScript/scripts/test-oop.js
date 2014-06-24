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