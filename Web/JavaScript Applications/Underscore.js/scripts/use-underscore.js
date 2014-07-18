var underScoreJSHomework = (function () {
    'use strict';

    var students = TestData.students;
    var animals = TestData.animals;
    var books = TestData.books;

    function filterAndSortStudents() {

        jsConsole.writeLine("Out of these students: ");
        jsConsole.writeLine(students);
        jsConsole.writeLine("Those are the ones whose first name is " +
            "before their last name alphabetically");

        var result = _.chain(students)
            .filter(function (student) {
                return student.firstName.localeCompare(student.lastName) < 0;
            })
            .sortBy(function (student) {
                return student.fullName();
            })
            .reverse()
            .value();

        jsConsole.writeLine(result);
    }

    function filterStudentsByAge() {

        jsConsole.writeLine("Out of these students: ");
        jsConsole.writeLine(students);
        jsConsole.writeLine("Those are the ones who are with age between 18 and 24");

        var result = _.chain(students)
            .filter(function (student) {
                return (student.age >= 18 && student.age <= 24);
            })
            .value();

        jsConsole.writeLine(result);
    }

    function getStudentWithTheHighestMarks() {

        jsConsole.writeLine("Out of these students: ");
        jsConsole.writeLine(students);
        jsConsole.writeLine("This is the student with the highest marks");

        var result = _.chain(students)
            .max(function (student) {
                var sumOfMarks = 0;

                _.each(student.marks, function (mark) {
                    sumOfMarks += mark;
                });

                return sumOfMarks / student.marks.length;
            })
            .value();

        jsConsole.writeLine(result);
    }

    function groupAnimalsByIDAndSortByNumberOfLegs() {
        jsConsole.writeLine("The animals grouped by species and leg count: ");

        var result = _.chain(animals)
            .groupBy('species')
            .sortBy(function (animal) {
                return animal.numberOfLegs;
            })
            .value();

        jsConsole.writeLine(result);
    }

    function sumLegsAmount() {
        jsConsole.writeLine("The sum of the legs of these animals: ");
        jsConsole.writeLine(animals);
        jsConsole.writeLine(' is: ');
        var result = 0;

        _.each(animals, function (animal) {
            result += animal.numberOfLegs;
        });

        jsConsole.writeLine(result);
    }

    function findMostPopularAuthor() {
        jsConsole.writeLine("Out of this collection of books: ");
        jsConsole.writeLine('\r\n \r\n');
        jsConsole.writeLine(books);

        var mostPopularAuthor = findMostCommonValueByKey(books, 'author');

        jsConsole.writeLine('\r\n \r\n');
        jsConsole.writeLine('The most popular author is: ' + mostPopularAuthor);
    }

    function findMostCommonFirstAndLastName() {
        jsConsole.writeLine("Out of these people: \r\n ");
        jsConsole.writeLine(students);
        jsConsole.writeLine('\r\n \r\n');

        var mostCommonFirstName = findMostCommonValueByKey(students, 'firstName');
        jsConsole.writeLine('The most common first name is: ' + mostCommonFirstName);

        var mostCommonLastName = findMostCommonValueByKey(students, 'lastName');

        jsConsole.writeLine('The most common last name is: ' + mostCommonLastName);

    }

    function findMostCommonValueByKey(collection, property) {
        return _.chain(collection)
            .countBy(property)
            .pairs()
            .max(_.last)
            .value()[0];
    }

    return {
        filterAndSortStudents: filterAndSortStudents,
        filterStudentsByAge: filterStudentsByAge,
        getStudentWithTheHighestMarks: getStudentWithTheHighestMarks,
        groupAnimalsByIDAndSortByNumberOfLegs: groupAnimalsByIDAndSortByNumberOfLegs,
        sumLegsAmount: sumLegsAmount,
        findMostPopularAuthor: findMostPopularAuthor,
        findMostCommonFirstAndLastName: findMostCommonFirstAndLastName
    }
}());