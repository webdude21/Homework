var propulsionModule = (function () {

    //easier inheritance
    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    //propulsion unit constructor
    var PropulsionUnit = function (acceleration) {
        this.acceleration = acceleration;
        return this;
    };

    //default acceleration value of undefined getAcceleration method
    PropulsionUnit.prototype.getAcceleration = function () {
        return this.acceleration;
    };

    //Wheel constructor
    var Wheel = function (wheelRadius) {
        this.radius = wheelRadius || 14;
        return this;
    };

    Wheel.inherit(PropulsionUnit);
    Wheel.prototype.getAcceleration = function () {
        return this.radius * 2 * Math.PI;
    };

    // propelling nozzle constructor
    var PropellingNozzle = function (power, afterBurnerState) {
        this.power = power;
        this.afterBurner = afterBurnerState;
        return this;
    };

    PropellingNozzle.inherit(PropulsionUnit);
    PropellingNozzle.prototype.getAcceleration = function () {
        return this.afterBurner ? this.power * 2 : this.power;
    };

    // propeller constructor
    var Propeller = function (numberOfFins, clockwise) {
        this.fins = numberOfFins;
        this.clockwise = clockwise || true;
        return this;
    };

    Propeller.inherit(PropulsionUnit);
    Propeller.prototype.getAcceleration = function () {
        return this.clockwise ? this.fins : this.fins * (-1);
    };

    return {
        Propeller: Propeller,
        PropellingNozzle: PropellingNozzle,
        Wheel: Wheel,
        PropulsionUnit: PropulsionUnit
    }
}());