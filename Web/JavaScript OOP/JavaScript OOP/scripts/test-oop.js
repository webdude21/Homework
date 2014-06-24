function testOOP() {
    console.log('---- amphibian tests ----');
    var amphibianTest = new vehicleModule.AmphibiousVehicle();
    amphibianTest.accelerate();
    console.log(amphibianTest.speed + ' in land mode');

    amphibianTest.toggleLandWaterMode();
    console.log(amphibianTest.speed + ' it should be 0!');
    amphibianTest.accelerate();
    console.log(amphibianTest.speed + ' in water mode');

    console.log('---- aircraft tests ----');
    var aircraftTest = new vehicleModule.AirVehicle();
    aircraftTest.accelerate();
    console.log(aircraftTest.speed + ' without afterburner');
    aircraftTest.speed = 0;

    aircraftTest.engageAfterburner();
    aircraftTest.accelerate();
    console.log(aircraftTest.speed + ' with afterburner engaged');
}