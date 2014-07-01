var Zoo;
(function (Zoo) {
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
//# sourceMappingURL=animal-cage.js.map
