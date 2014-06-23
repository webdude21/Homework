var vehicleModule = (function () {

    // easier inheritance
    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    //vehicle unit
    var Vehicle = function () {
        this.speed = 0;
        this.propulsionUnits = [];
        return this;
    };

    Vehicle.prototype.accelerate = function () {
        var that = this;
        this.propulsionUnits.forEach(function (item) {
            that.speed += item.getAcceleration();
        });
    };

    //land vehicle unit
    var LandVehicle = function () {
        var wheelCount = 4;
        var wheelSize = 16;

        for (var i = 0; i < wheelCount; i++) {
            this.propulsionUnits.push(new propulsionModule.Wheel(wheelSize));
        }
        return this;
    };

    LandVehicle.inherit(Vehicle);

    // air vehicle unit
    var AirVehicle = function () {
        var nozzlePower = 10;
        this.propulsionUnits.push(new propulsionModule.PropellingNozzle(nozzlePower));
        return this;
    };

    AirVehicle.inherit(Vehicle);

    AirVehicle.prototype.disengageAfterburner = function () {
        this.propulsionUnits.forEach(function (item) {
            item.afterBurner = false;
        });
    };

    AirVehicle.prototype.engageAfterburner = function () {
        this.propulsionUnits.forEach(function (item) {
            item.afterBurner = true;
        });
    };

    // water vehicle unit
    var WaterVehicle = function (propellerCount) {
        var propellerFinsCount = 16;

        for (var i = 0; i < propellerCount; i++) {
            this.propulsionUnits.push(new propulsionModule.Propeller(propellerFinsCount));
        }

        return this;
    };

    WaterVehicle.inherit(Vehicle);

    WaterVehicle.prototype.setPropellerDirectionCounterClockwise = function () {
        this.propulsionUnits.forEach(function (item) {
            item.clockwise = false;
        });
    };

    WaterVehicle.prototype.setPropellerDirectionClockwise = function () {
        this.propulsionUnits.forEach(function (item) {
            item.clockwise = true;
        });
    };

    // AmphibiousVehicle vehicle unit
    var AmphibiousVehicle = function (landMode) {
        this.landMode = landMode || true;
        this.internalLandVehicle = new LandVehicle();
        this.internalWaterVehicle = new WaterVehicle(6);
        return this;
    };

    AmphibiousVehicle.inherit(Vehicle);

    AmphibiousVehicle.prototype.toggleLandWaterMode = function () {
        if (this.landMode) {
            this.internalLandVehicle.speed = 0;
            this.speed = 0;
            this.landMode = false;
        } else {
            this.internalWaterVehicle.speed = 0;
            this.speed = 0;
            this.landMode = true;
        }
    };

    AmphibiousVehicle.prototype.accelerate = function () {
        if (this.landMode) {
            this.internalLandVehicle.accelerate();
            this.speed = this.internalLandVehicle.speed;
        } else {
            this.internalWaterVehicle.accelerate();
            this.speed = this.internalWaterVehicle.speed;
        }
    };

    return {
        Vehicle: Vehicle,
        LandVehicle: LandVehicle,
        WaterVehicle: WaterVehicle,
        AirVehicle: AirVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    }
}());