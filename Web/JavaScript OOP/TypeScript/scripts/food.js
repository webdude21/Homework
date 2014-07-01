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
//# sourceMappingURL=food.js.map
