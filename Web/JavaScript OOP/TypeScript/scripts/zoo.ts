module Zoo {
    "use strict";

    export interface IAnimal {
        name: string;
        lifeExpectancy: number;
        diet: AnimalProperties.Diet;
        socialBehaviour: AnimalProperties.SocialBehavior;
        environment: AnimalProperties.Environment;
        state: AnimalProperties.State;

        procreate(childName:string): IAnimal;
        feedChild(child:any): string;
        makeSound(): string;
        move(): string;
        sleep(): string;
        eat(any): string;
    }

    export class Animal {
        name:string;
        lifeExpectancy:number;
        legCount:number;
        diet:AnimalProperties.Diet;
        socialBehaviour:AnimalProperties.SocialBehavior;
        environment:AnimalProperties.Environment;
        state:AnimalProperties.State;

        constructor(name:string, lifeExpectancy:number, diet:AnimalProperties.Diet,
                    socialBehaviour:AnimalProperties.SocialBehavior,
                    environment:AnimalProperties.Environment, legCount?:number) {

            this.name = name;
            this.lifeExpectancy = lifeExpectancy;
            this.diet = diet;
            this.socialBehaviour = socialBehaviour;
            this.environment = environment;
            this.legCount = legCount || 0;
            this.state = new AnimalProperties.State(false, true, true);
        }

        toString() {
            return 'my kind usually lives up to ' + this.lifeExpectancy + ' years. ' + "I've got " +
                (this.legCount > 0 ? this.legCount.toString() : 'no') + " legs";
        }
    }

    export class Mammal extends Animal {
        constructor(name:string, lifeExpectancy:number, diet:AnimalProperties.Diet,
                    socialBehaviour:AnimalProperties.SocialBehavior,
                    environment:AnimalProperties.Environment, legCount?:number) {
            super(name, lifeExpectancy, diet, socialBehaviour, environment, legCount);
        }

        static breastFeed(child:Mammal) {
            if (child instanceof Mammal) {
                child.state.happy = true;
                child.state.healthy = false;
            } else {
                throw new Error('Can only breast feed other Mammals!');
            }
        }
    }

    export class Reptile extends Animal {
        constructor(name:string, lifeExpectancy:number, diet:AnimalProperties.Diet,
                    socialBehaviour:AnimalProperties.SocialBehavior,
                    environment:AnimalProperties.Environment, legCount?:number) {
            super(name, lifeExpectancy, diet, socialBehaviour, environment, legCount);
        }
    }

    export class Snake extends Reptile implements IAnimal {
        hibernating:boolean;

        constructor(name:string) {
            super(name, 30, AnimalProperties.Diet.Carnivore,
                AnimalProperties.SocialBehavior.Revengeful,
                AnimalProperties.Environment.Jungle);
            this.hibernating = false;
        }

        eat(food:Food.Meat) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        }

        move() {
            return this.name + ' just jumped from the tree!';
        }

        makeSound() {
            return this.name + ': Ssssssss!';
        }

        sleep() {
            return this.name + ' fell asleep on the tree!';
        }

        feedChild(child:Animal) {
            return this.name + ' fed ' + child.name + ' with some ' + Food.Meat.RedMead.toString();
        }

        procreate(childName:string) {
            return Zoo.Snake.hatchEggs(childName);
        }


        toggleHibernation() {
            this.hibernating = !this.hibernating;
        }

        private static hatchEggs(childName:string) {
            return new Snake(childName);
        }

        toString() {
            return "My name is " + this.name + ". I'm a snake, " + super.toString();
        }
    }

    export class SeaTurtle extends Reptile implements IAnimal {
        hibernating:boolean;

        constructor(name:string) {
            super(name, 250, AnimalProperties.Diet.Omnivore,
                AnimalProperties.SocialBehavior.Altruistic,
                AnimalProperties.Environment.Sea);
            this.hibernating = false;
        }

        eat(food:Food.SeaFood) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        }

        move() {
            return this.name + ' swims across the pond!';
        }

        makeSound() {
            return this.name + ': .... !';
        }

        sleep() {
            return this.name + ' fell asleep on the shore!';
        }

        feedChild(child:Animal) {
            return this.name + ' fed ' + child.name + ' with some ' + Food.SeaFood.Molluscs;
        }

        procreate(childName:string) {
            return Zoo.SeaTurtle.hatchEggs(childName);
        }

        private static hatchEggs(childName:string) {
            return new SeaTurtle(childName);
        }

        toString() {
            return "My name is " + this.name + ". I'm a Sea Turtle, " + super.toString();
        }
    }

    export class Monkey extends Animal implements IAnimal {
        constructor(name:string) {
            super(name, 25, AnimalProperties.Diet.Herbivore,
                AnimalProperties.SocialBehavior.Altruistic,
                AnimalProperties.Environment.Jungle, 4);
        }

        eat(food:Food.Fruit) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        }

        move() {
            return this.name + ' just jumped from the tree!';
        }

        makeSound() {
            return this.name + ': Eeek, eeek!';
        }

        sleep() {
            return this.name + ' fell asleep on the tree!';
        }

        feedChild(child:Animal) {
            return this.name + ' breast fed ' + child.name;
        }

        procreate(childName:string) {
            return Zoo.Monkey.giveBirth(childName);
        }

        private static giveBirth(childName:string) {
            return new Monkey(childName);
        }

        toString() {
            return "My name is " + this.name + ". I'm a monkey, " + super.toString();
        }
    }

    export class PolarBear extends Animal implements IAnimal {
        hibernating:boolean;

        constructor(name:string) {
            super(name, 30, AnimalProperties.Diet.Omnivore,
                AnimalProperties.SocialBehavior.Cooperative,
                AnimalProperties.Environment.Arctic, 4);
            this.hibernating = false;
        }

        eat(food:any) {
            this.state.happy = true;
            this.state.hungry = false;
            return this.name + ' just ate ' + food.toString();
        }

        move() {
            return this.name + ' jumped on an iceberg!';
        }

        makeSound() {
            return this.name + ': GRRRRR!';
        }

        sleep() {
            this.state.happy = true;
            return this.name + ' fell asleep on the ice!';
        }

        feedChild(child:Animal) {
            return this.name + ' breast fed ' + child.name;
        }

        procreate(childName:string) {
            return Zoo.PolarBear.giveBirth(childName);
        }

        toggleHibernation() {
            this.hibernating = !this.hibernating;
        }

        private static giveBirth(childName:string) {
            return new PolarBear(childName);
        }

        toString() {
            return "My name is " + this.name + ". I'm a Polar Bear, " + super.toString();
        }
    }

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

        getAnimalAtIndex (index: number): T{
            if (index < this.internalStorage.length){
                return this.internalStorage[index];
            } else{
                throw new ReferenceError("Index out of range");
            }
        }

        forEach(callback: () => any) {
            this.internalStorage.forEach(callback);
        }
    }
}

module AnimalProperties {
    "use strict";
    export enum Diet { Carnivore, Herbivore, Omnivore }
    export enum SocialBehavior { Egoistic, Cooperative, Altruistic, Revengeful }
    export enum Environment { Forest, Plains, Jungle, Urban, Arctic, Sea, Ocean, River }

    export class State {
        hungry:boolean;
        healthy:boolean;
        happy:boolean;

        constructor(hungry?:boolean, healthy?:boolean, happy?:boolean) {
            this.hungry = hungry || true;
            this.healthy = healthy || true;
            this.happy = happy || true;
        }
    }
}

module Food {
    export enum Meat { WhiteMeat, RedMead, Fat }
    export enum Fruit { Banana, Orange, Apple, Pear, Cherry, Strawberry }
    export enum Veggies { Carrots, EggPlant, Tomatoes, Potatoes, Cucumbers }
    export enum SeaFood { Fish, Crustaceans, Molluscs, Algae }
}

