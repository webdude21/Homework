// Write a function that groups an array of persons by age, first or last name.
// The function must return an associative array, with keys - the groups,
// and values -arrays with persons in this groups.
// Use function overloading (i.e. just one function)

function test() {
    var persons = [
        {firstname: "Gosho", lastname: "Petrov", age: 32},
        {firstname: "Bay", lastname: "Ivan", age: 23},
        {firstname: "Pesho", lastname: "Georgiev", age: 19},
        {firstname: "Michael", lastname: "Bay", age: 81}
    ];

    var groupedByFname = group(persons, "firstname");
    var groupedByAge = group(persons, "age");
}

function group(persons, prop) {
    var result = {};

    persons.forEach(function (person) {
        var value = person[prop];
        result[value] = result[value] || [];
        result[value].push(person);
    });
    return result;
}