var schoolSystem = (function () {

    /* easier inheritance */
    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    /* SchoolClass constructor */
    function SchoolClass(className, formTeacher, capacity, students) {
        this.className = className;
        this.formTeacher = formTeacher;
        this.capacity = parseInt(capacity) || 20;
        var studentsArr = [];

        for (var index = 0; index < students.length; index++) {

            if (this.capacity >= students.length) {
                if (students[index] instanceof Student) {
                    studentsArr.push(students[index]);
                } else {
                    throw new TypeError('The arguments of the ' +
                        'SchoolClass constructor should be instances of Student!');
                }
            } else {
                throw new RangeError('The maximum ammount of students ' +
                    'in this class is: ' + this.capacity);
            }
        }
        return this;
    }

    /* School constructor */
    function School(schoolName, town) {
        this.name = schoolName;
        this.town = town;
        var classes = [];

        this.addClass = function addClass(classToAdd) {
            if (classToAdd instanceof SchoolClass) {
                classes.push()
            } else {
                throw new TypeError('classToAdd should be of an instance of SchoolClass!');
            }
        };

        this.removeClass = function removeClass(classToRemove) {
            var indexToRemove = classes.indexOf(classToRemove);

            if (indexToRemove > -1) {
                classes.splice(indexToRemove, 1);
            } else {
                throw new ReferenceError("There's no such class in this School!")
            }
        };

        return this;
    }

    /* Person constructor */
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;

        return this;
    }

    Person.prototype.intoduce = function introduce() {
        var introductionString = '';
        for (var prop in this) {
            if (this.hasOwnProperty(prop)) {
                introductionString += (prop + ': ' + this[prop] + ', ');
            }
        }

        return introductionString.slice(0, introductionString.length - 2);
    };

    /* Student constructor */
    function Student(firstName, lastName, age, grade) {
        Person.call(this, firstName, lastName, age);
        this.grade = grade;

        return this;
    }

    Student.inherit(Person);

    /* Teacher constructor */
    function Teacher(firstName, lastName, age, specialty) {
        Person.call(this, firstName, lastName, age);
        this.specialty = specialty;

        return this;
    }

    Teacher.inherit(Person);

    return{
        Person: Person,
        Student: Student,
        Teacher: Teacher,
        School: School,
        SchoolClass: SchoolClass
    }
}());