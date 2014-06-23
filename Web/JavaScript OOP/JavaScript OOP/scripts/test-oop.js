function testOOP() {
    var amphibianTest = new vehicleModule.AmphibiousVehicle();
    amphibianTest.accelerate();
    console.log(amphibianTest.speed);

    amphibianTest.toggleLandWaterMode();
    console.log(amphibianTest.speed + " It should be 0!");
    amphibianTest.accelerate();
    console.log(amphibianTest.speed);
}