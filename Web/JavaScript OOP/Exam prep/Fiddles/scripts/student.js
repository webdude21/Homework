define([], function () {
    'use strict';
    var Student;
    Student = (function () {
        function Student(fName, lName, age) {
            this.firstName = fName;
            this.lastName = lName;
            this.age = age;
        }

        Student.prototype = {
            getFirstName: function () {
                return this.firstName;
            },
            getAge: function () {
                return this.age;
            }
        };

        return Student;
    }());
    return Student;
});