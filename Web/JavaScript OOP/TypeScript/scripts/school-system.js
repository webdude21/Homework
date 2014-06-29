var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var schoolSystem;
(function (schoolSystem) {
    var Person = (function () {
        function Person(firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        Person.prototype.toString = function () {
            return 'My name is: ' + this.firstName + ' ' + this.lastName + " and I'm " + this.age + ' years old';
        };
        return Person;
    })();
    schoolSystem.Person = Person;

    var Student = (function (_super) {
        __extends(Student, _super);
        function Student(firstName, lastName, age, grade) {
            _super.call(this, firstName, lastName, age);
            this.grade = grade;
        }
        Student.prototype.toString = function () {
            return _super.prototype.toString.call(this) + ', my grade is: ' + this.grade;
        };
        return Student;
    })(Person);
    schoolSystem.Student = Student;

    var Teacher = (function (_super) {
        __extends(Teacher, _super);
        function Teacher(firstName, lastName, age, specialty) {
            _super.call(this, firstName, lastName, age);
            this.specialty = specialty;
        }
        Teacher.prototype.toString = function () {
            return _super.prototype.toString.call(this) + ', specialty is: ' + this.specialty;
        };
        return Teacher;
    })(Person);
    schoolSystem.Teacher = Teacher;

    var SchoolClass = (function () {
        function SchoolClass(teacher, students) {
            this.teacher = teacher;
            if (students) {
                this.students = students;
            } else {
                this.students = [];
            }
        }
        SchoolClass.prototype.addStudents = function (students) {
            for (var i = 0; i < students.length; i++) {
                this.students.push(students[i]);
            }
        };

        SchoolClass.prototype.toString = function () {
            return this.students.join(' - ');
        };
        return SchoolClass;
    })();
    schoolSystem.SchoolClass = SchoolClass;
})(schoolSystem || (schoolSystem = {}));
//# sourceMappingURL=school-system.js.map
