/// <reference path="food.ts"/>
/// <reference path="animal-properties.ts"/>
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Zoo;
(function (Zoo) {
    "use strict";

    var Animal = (function () {
        function Animal(name, lifeExpectancy, diet, socialBehaviour, environment, legCount) {
            this.name = name;
            this.lifeExpectancy = lifeExpectancy;
            this.diet = diet;
            this.socialBehaviour = socialBehaviour;
            this.environment = environment;
            this.legCount = legCount;
            this.state = new AnimalProperties.State(false, true, true);
        }
        Animal.prototype.toString = function () {
            return 'my kind usually lives up to ' + this.lifeExpectancy + ' years. ' + "I've got " + (this.legCount > 0 ? this.legCount.toString() : 'no') + " legs";
        };
        return Animal;
    })();
    Zoo.Animal = Animal;

    var Mammal = (function (_super) {
        __extends(Mammal, _super);
        function Mammal(name, lifeExpectancy, diet, socialBehaviour, environment, legCount) {
            _super.call(this, name, lifeExpectancy, diet, socialBehaviour, environment, legCount);
        }
        Mammal.breastFeed = function (child) {
            if (child instanceof Mammal) {
                child.state.happy = true;
                child.state.healthy = false;
            } else {
                throw new Error('Can only breast feed other Mammals!');
            }
        };
        return Mammal;
    })(Animal);
    Zoo.Mammal = Mammal;

    var Reptile = (function (_super) {
        __extends(Reptile, _super);
        function Reptile(name, lifeExpectancy, diet, socialBehaviour, environment, legCount) {
            _super.call(this, name, lifeExpectancy, diet, socialBehaviour, environment, legCount);
        }
        return Reptile;
    })(Animal);
    Zoo.Reptile = Reptile;

    var Snake = (function (_super) {
        __extends(Snake, _super);
        function Snake(name) {
            _super.call(this, name, 30, 0 /* Carnivore */, 3 /* Revengeful */, 2 /* Jungle */);
            this.hibernating = false;
        }
        Snake.prototype.eat = function (food) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        };

        Snake.prototype.move = function () {
            return this.name + ' just jumped from the tree!';
        };

        Snake.prototype.makeSound = function () {
            return this.name + ': Ssssssss!';
        };

        Snake.prototype.sleep = function () {
            return this.name + ' fell asleep on the tree!';
        };

        Snake.prototype.feedChild = function (child) {
            return this.name + ' fed ' + child.name + ' with some ' + 1 /* RedMead */.toString();
        };

        Snake.prototype.procreate = function (childName) {
            return Zoo.Snake.hatchEggs(childName);
        };

        Snake.prototype.toggleHibernation = function () {
            this.hibernating = !this.hibernating;
        };

        Snake.hatchEggs = function (childName) {
            return new Snake(childName);
        };

        Snake.prototype.toString = function () {
            return "My name is " + this.name + ". I'm a snake, " + _super.prototype.toString.call(this);
        };
        return Snake;
    })(Reptile);
    Zoo.Snake = Snake;

    var SeaTurtle = (function (_super) {
        __extends(SeaTurtle, _super);
        function SeaTurtle(name) {
            _super.call(this, name, 250, 2 /* Omnivore */, 2 /* Altruistic */, 5 /* Sea */);
            this.hibernating = false;
        }
        SeaTurtle.prototype.eat = function (food) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        };

        SeaTurtle.prototype.move = function () {
            return this.name + ' swims across the pond!';
        };

        SeaTurtle.prototype.makeSound = function () {
            return this.name + ': .... !';
        };

        SeaTurtle.prototype.sleep = function () {
            return this.name + ' fell asleep on the shore!';
        };

        SeaTurtle.prototype.feedChild = function (child) {
            return this.name + ' fed ' + child.name + ' with some ' + 2 /* Molluscs */;
        };

        SeaTurtle.prototype.procreate = function (childName) {
            return Zoo.SeaTurtle.hatchEggs(childName);
        };

        SeaTurtle.hatchEggs = function (childName) {
            return new SeaTurtle(childName);
        };

        SeaTurtle.prototype.toString = function () {
            return "My name is " + this.name + ". I'm a Sea Turtle, " + _super.prototype.toString.call(this);
        };
        return SeaTurtle;
    })(Reptile);
    Zoo.SeaTurtle = SeaTurtle;

    var Monkey = (function (_super) {
        __extends(Monkey, _super);
        function Monkey(name) {
            _super.call(this, name, 25, 1 /* Herbivore */, 2 /* Altruistic */, 2 /* Jungle */, 4);
        }
        Monkey.prototype.eat = function (food) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        };

        Monkey.prototype.move = function () {
            return this.name + ' just jumped from the tree!';
        };

        Monkey.prototype.makeSound = function () {
            return this.name + ': Eeek, eeek!';
        };

        Monkey.prototype.sleep = function () {
            return this.name + ' fell asleep on the tree!';
        };

        Monkey.prototype.feedChild = function (child) {
            return this.name + ' breast fed ' + child.name;
        };

        Monkey.prototype.procreate = function (childName) {
            return Zoo.Monkey.giveBirth(childName);
        };

        Monkey.giveBirth = function (childName) {
            return new Monkey(childName);
        };

        Monkey.prototype.toString = function () {
            return "My name is " + this.name + ". I'm a monkey, " + _super.prototype.toString.call(this);
        };
        return Monkey;
    })(Animal);
    Zoo.Monkey = Monkey;

    var PolarBear = (function (_super) {
        __extends(PolarBear, _super);
        function PolarBear(name) {
            _super.call(this, name, 30, 2 /* Omnivore */, 1 /* Cooperative */, 4 /* Arctic */, 4);
            this.hibernating = false;
        }
        PolarBear.prototype.eat = function (food) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        };

        PolarBear.prototype.move = function () {
            return this.name + ' jumped on an iceberg!';
        };

        PolarBear.prototype.makeSound = function () {
            return this.name + ': GRRRRR!';
        };

        PolarBear.prototype.sleep = function () {
            this.state.happy = true;
            return this.name + ' fell asleep on the ice!';
        };

        PolarBear.prototype.feedChild = function (child) {
            return this.name + ' breast fed ' + child.name;
        };

        PolarBear.prototype.procreate = function (childName) {
            return Zoo.PolarBear.giveBirth(childName);
        };

        PolarBear.prototype.toggleHibernation = function () {
            this.hibernating = !this.hibernating;
        };

        PolarBear.giveBirth = function (childName) {
            return new PolarBear(childName);
        };

        PolarBear.prototype.toString = function () {
            return "My name is " + this.name + ". I'm a Polar Bear, " + _super.prototype.toString.call(this);
        };
        return PolarBear;
    })(Animal);
    Zoo.PolarBear = PolarBear;
})(Zoo || (Zoo = {}));
//# sourceMappingURL=zoo.js.map
