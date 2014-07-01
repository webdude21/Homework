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
            this.legCount = legCount || 0;
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

    var AnimalCage = (function () {
        function AnimalCage(capacity) {
            this.capacity = capacity || 50;
            this.internalStorage = [];
        }
        AnimalCage.prototype.addAnimal = function (item) {
            if (this.capacity >= this.internalStorage.length) {
                this.internalStorage.push(item);
            } else {
                throw new RangeError("You've exceeded the maximum capacity (" + this.capacity + ") of the cage.");
            }
        };

        AnimalCage.prototype.removeAnimal = function (item) {
            var itemIndex = this.internalStorage.indexOf(item);
            if (itemIndex > -1) {
                this.internalStorage.splice(itemIndex, 1);
            }
        };

        AnimalCage.prototype.getAnimalCount = function () {
            return this.internalStorage.length;
        };

        AnimalCage.prototype.toString = function () {
            return this.internalStorage.join(', \r\n');
        };

        AnimalCage.prototype.getAnimalAtIndex = function (index) {
            if (index < this.internalStorage.length) {
                return this.internalStorage[index];
            } else {
                throw new ReferenceError("Index out of range");
            }
        };
        return AnimalCage;
    })();
    Zoo.AnimalCage = AnimalCage;
})(Zoo || (Zoo = {}));

var AnimalProperties;
(function (AnimalProperties) {
    "use strict";
    (function (Diet) {
        Diet[Diet["Carnivore"] = 0] = "Carnivore";
        Diet[Diet["Herbivore"] = 1] = "Herbivore";
        Diet[Diet["Omnivore"] = 2] = "Omnivore";
    })(AnimalProperties.Diet || (AnimalProperties.Diet = {}));
    var Diet = AnimalProperties.Diet;
    (function (SocialBehavior) {
        SocialBehavior[SocialBehavior["Egoistic"] = 0] = "Egoistic";
        SocialBehavior[SocialBehavior["Cooperative"] = 1] = "Cooperative";
        SocialBehavior[SocialBehavior["Altruistic"] = 2] = "Altruistic";
        SocialBehavior[SocialBehavior["Revengeful"] = 3] = "Revengeful";
    })(AnimalProperties.SocialBehavior || (AnimalProperties.SocialBehavior = {}));
    var SocialBehavior = AnimalProperties.SocialBehavior;
    (function (Environment) {
        Environment[Environment["Forest"] = 0] = "Forest";
        Environment[Environment["Plains"] = 1] = "Plains";
        Environment[Environment["Jungle"] = 2] = "Jungle";
        Environment[Environment["Urban"] = 3] = "Urban";
        Environment[Environment["Arctic"] = 4] = "Arctic";
        Environment[Environment["Sea"] = 5] = "Sea";
        Environment[Environment["Ocean"] = 6] = "Ocean";
        Environment[Environment["River"] = 7] = "River";
    })(AnimalProperties.Environment || (AnimalProperties.Environment = {}));
    var Environment = AnimalProperties.Environment;

    var State = (function () {
        function State(hungry, healthy, happy) {
            this.hungry = hungry || true;
            this.healthy = healthy || true;
            this.happy = happy || true;
        }
        return State;
    })();
    AnimalProperties.State = State;
})(AnimalProperties || (AnimalProperties = {}));

var Food;
(function (Food) {
    (function (Meat) {
        Meat[Meat["WhiteMeat"] = 0] = "WhiteMeat";
        Meat[Meat["RedMead"] = 1] = "RedMead";
        Meat[Meat["Fat"] = 2] = "Fat";
    })(Food.Meat || (Food.Meat = {}));
    var Meat = Food.Meat;
    (function (Fruit) {
        Fruit[Fruit["Banana"] = 0] = "Banana";
        Fruit[Fruit["Orange"] = 1] = "Orange";
        Fruit[Fruit["Apple"] = 2] = "Apple";
        Fruit[Fruit["Pear"] = 3] = "Pear";
        Fruit[Fruit["Cherry"] = 4] = "Cherry";
        Fruit[Fruit["Strawberry"] = 5] = "Strawberry";
    })(Food.Fruit || (Food.Fruit = {}));
    var Fruit = Food.Fruit;
    (function (Veggies) {
        Veggies[Veggies["Carrots"] = 0] = "Carrots";
        Veggies[Veggies["EggPlant"] = 1] = "EggPlant";
        Veggies[Veggies["Tomatoes"] = 2] = "Tomatoes";
        Veggies[Veggies["Potatoes"] = 3] = "Potatoes";
        Veggies[Veggies["Cucumbers"] = 4] = "Cucumbers";
    })(Food.Veggies || (Food.Veggies = {}));
    var Veggies = Food.Veggies;
    (function (SeaFood) {
        SeaFood[SeaFood["Fish"] = 0] = "Fish";
        SeaFood[SeaFood["Crustaceans"] = 1] = "Crustaceans";
        SeaFood[SeaFood["Molluscs"] = 2] = "Molluscs";
        SeaFood[SeaFood["Algae"] = 3] = "Algae";
    })(Food.SeaFood || (Food.SeaFood = {}));
    var SeaFood = Food.SeaFood;
})(Food || (Food = {}));
//# sourceMappingURL=zoo.js.map
