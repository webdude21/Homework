// Write a function that finds the youngest person in
// a given array of persons and prints his/hers full name

function test() {
    var persons = [
        { firstname: "Gosho", lastname: "Petrov", age: 32 },
        { firstname: "Bay", lastname: "Ivan", age: 23 },
        { firstname: "Pesho", lastname: "Georgiev", age: 19 },
        { firstname: "Michael", lastname: "Bay", age: 81 }];
    printInitialArray(persons);
    jsConsole.write('The youngest person is: ');
    findYoungestPerson(persons);
}

function printInitialArray(arr) {
    for (var index = 0; index < arr.length; index++) {
        var obj = arr[index];
        jsConsole.writeLine('First name: ' + obj.firstname +
            ' Last name: ' + obj.lastname + ' Age: ' + obj.age);
    }
}

function comparePersons(a, b) {
    if (a.age < b.age)
        return -1;
    if (a.age > b.age)
        return 1;
    return 0;
}

function findYoungestPerson(personArr) {
    personArr.sort(comparePersons);
    jsConsole.writeLine(personArr[0].firstname + ' ' + personArr[0].lastname);
}