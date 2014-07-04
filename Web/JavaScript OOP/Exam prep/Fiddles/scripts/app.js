(function () {
    require(['student'], function (Student) {
        var testStudent = new Student('Petar', "Petrov", 50);

        console.log(testStudent.getFirstName());
        console.log(testStudent.getAge());

        Student.prototype.getLastName = function () {
            return this.lastName;
        };

        var anotherStudent = new Student('Georgi', 'Gankov', 55);

        console.log(anotherStudent.getLastName());
    })
}());
