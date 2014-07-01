module Zoo {
    export class AnimalCage<T> {
        private internalStorage:T[];
        capacity:number;

        constructor(capacity?:number) {
            this.capacity = capacity || 50;
            this.internalStorage = [];
        }

        addAnimal(item:T) {
            if (this.capacity >= this.internalStorage.length) {
                this.internalStorage.push(item);
            } else {
                throw new RangeError("You've exceeded the maximum capacity (" + this.capacity +
                    ") of the cage.");
            }
        }

        removeAnimal(item:T) {
            var itemIndex = this.internalStorage.indexOf(item);
            if (itemIndex > -1) {
                this.internalStorage.splice(itemIndex, 1);
            }
        }

        getAnimalCount() {
            return this.internalStorage.length;
        }

        toString() {
            return this.internalStorage.join(', \r\n');
        }

        getAnimalAtIndex(index:number):T {
            if (index < this.internalStorage.length) {
                return this.internalStorage[index];
            } else {
                throw new ReferenceError("Index out of range");
            }
        }
    }
}