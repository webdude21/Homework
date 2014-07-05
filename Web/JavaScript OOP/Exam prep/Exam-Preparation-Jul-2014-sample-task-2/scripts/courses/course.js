define(['courses/student'], function (Student) {
    var Course;
    Course = (function () {

        function Course(title, formulaFunction) {
            this._title = title;
            this._formulaFunction = formulaFunction;
            this._students = [];
            this._calculated = false;
        }

        Course.prototype.addStudent = function (student) {
            if (student instanceof Student) {
                this._students.push(student);
                this._calculated = false;
            } else {
                throw new TypeError('You should supply an ' +
                    'object of the Student type.')
            }
            return this;
        };

        Course.prototype.calculateResults = function () {
            var that = this;
            this._calculated = true;
            this._students.forEach(function (student) {
                student.setTotalScore(that._formulaFunction(student));
            });
        };

        function checkIfCalculated() {
            if (this._calculated === false) {
                throw new Error('You must calculate the ' +
                    'results before requesting queries')
            }
        }

        function getSortedStudentsByParams(array, descending, property, studentsCount) {
            if (descending) {
                array.sort(function (firstStudent, secondStudent) {
                    return secondStudent[property] - firstStudent[property];
                });
            } else {
                array.sort(function (firstStudent, secondStudent) {
                    return firstStudent[property] - secondStudent[property];
                });
            }

            return array.slice(0, studentsCount);
        }

        Course.prototype.getTopStudentsByExam = function (studentsCount) {
            return getSortedStudentsByParams(this._students, true, 'exam', studentsCount);
        };

        Course.prototype.getTopStudentsByTotalScore = function (studentsCount) {
            checkIfCalculated();
            return getSortedStudentsByParams(this._students, true, 'totalScore', studentsCount);
        };

        return Course
    }());
    return Course
});
