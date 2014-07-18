var TestData = (function () {
    'use strict';

    var Student = Object.create({
        init: function (firstName, lastName, age, marks) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.marks = marks;
            return this;
        },
        fullName: function () {
            return this.firstName + ' ' + this.lastName;
        },
        toString: function () {
            return this.fullName();
        }
    });

    var Animal = Object.create({
        init: function (name, species, numberOfLegs) {
            this.name = name;
            this.species = species;
            this.numberOfLegs = numberOfLegs;
            return this;
        },
        toString: function () {
            return 'My name is ' + this.name + "I'm from the " +
                this.species + ' species, and I have ' + this.numberOfLegs + ' legs.';
        }
    });

    var Book = Object.create({
        init: function (author, title) {
            this.author = author;
            this.title = title;
            return this;
        },
        toString: function () {
            return this.title + ' by ' + this.author;
        }
    });

    var students = [
        Object.create(Student).init('Georgi', 'Gankov', 45, [5, 6, 4, 3, 6]),
        Object.create(Student).init('Petar', 'Petrov', 34, [2, 2, 5, 4, 2]),
        Object.create(Student).init('Stanislav', 'Slavov', 21, [6, 4, 5, 6, 6, 6, 2, 2, 4]),
        Object.create(Student).init('Mityo', 'TheGun', 77, [3, 3, 3, 4, 5, 2, 6, 5]),
        Object.create(Student).init('Dimo', 'Petrov', 22, [6, 6, 6, 4, 5, 6, 5, 6, 5, 6]),
        Object.create(Student).init('Georgi', 'Mihailov', 15, [6, 4, 5, 5])
    ];

    var animals = [
        Object.create(Animal).init('100 legged bug', 'insect', 100),
        Object.create(Animal).init('Joe The Bear', 'mammal', 4),
        Object.create(Animal).init('Pesho', 'mammal', 2),
        Object.create(Animal).init('Mosquito 1', 'insect', 6),
        Object.create(Animal).init('Another 60 legged bug', 'insect', 60),
        Object.create(Animal).init('Another Joe The Bear', 'mammal', 4),
        Object.create(Animal).init('Another Pesho', 'mammal', 2),
        Object.create(Animal).init('Another Mosquito 1', 'insect', 6),
        Object.create(Animal).init('Yet Another 80 legged bug', 'insect', 80),
        Object.create(Animal).init('Yet Another Joe The Bear', 'mammal', 4),
        Object.create(Animal).init('Yet Another Pesho', 'mammal', 2),
        Object.create(Animal).init('Yet Another Mosquito 1', 'insect', 6)
    ];

    var books = [
        Object.create(Book).init("Francis Scott Fizgerald", "The Great Gatsby"),
        Object.create(Book).init("Joan Rowling", "Harry Potters and the Deathly Hallows"),
        Object.create(Book).init("Joan Rowling", "Harry Potters and the Chamber of Secrets"),
        Object.create(Book).init("Joan Rowling", "Harry Potter and the Goblet of Fire"),
        Object.create(Book).init("John Steinback", "East from Heaven"),
        Object.create(Book).init("Vladimir Nabokov", "Lolita"),
        Object.create(Book).init("Astrid Lindgren", "Pippie The Long Stocking"),
        Object.create(Book).init("Astrid Lindgren", "Emil from Ljoneberya")
    ];

    return {
        students: students,
        animals: animals,
        books: books
    }
}());