define(['courses/student'], function (Student) {
    'use strict';
    var Course;
    Course = (function () {

        // shared private method
        function _getRanking(rankingList, studentsCount) {
            if (studentsCount >= rankingList.length) {
                throw new RangeError('The amount of students requested' +
                    ' is greater than the amount in the array');
            }
            return rankingList.slice(0, studentsCount);
        }

        // Function Constructor
        var Course = (function (courseName, formula) {
            this._formula = formula;
            this.title = courseName;
            this._students = [];
            this._rankingByExam = [];
            this._rankingByTotalScore = [];
        });

        Course.prototype.addStudent = function (student) {
            if (student instanceof Student) {
                this._students.push(student);
            } else {
                throw new TypeError('You can add only add the Student type!');
            }
            return this
        };

        Course.prototype.calculateResults = function () {
            var self = this;
            var totalScore;

            this._students.forEach(function (student) {
                totalScore = self._formula(student);
                self._rankingByTotalScore.push({
                    student: student,
                    score: totalScore
                });
                self._rankingByExam.push({
                    student: student,
                    score: student.exam
                })
            });

            self._rankingByTotalScore.sort(function (studentOne, studentTwo) {
                return studentTwo.score - studentOne.score;
            });

            self._rankingByExam.sort(function (studentOne, studentTwo) {
                return studentTwo.score - studentOne.score;
            });

            return this;
        };

        Course.prototype.getTopStudentsByTotalScore = function (studentsCount) {
            return _getRanking(this._rankingByTotalScore, studentsCount);
        };

        Course.prototype.getTopStudentsByExam = function (studentsCount) {
            return _getRanking(this._rankingByExam, studentsCount);
        };

        return Course;
    }());

    return Course;
});