define(['courses/student'], function (Student) {
    'use strict';
    var Course = (function () {
        // shared private method
        var _getRanking = function (rankingList, studentsCount) {
            var result = [];
            rankingList.sort(function (studentOne, studentTwo) {
                return studentTwo.score - studentOne.score;
            });

            for (var i = 0; i < studentsCount; i++) {
                result.push(rankingList[i]);
            }
            return result
        };

        var Course = (function (courseName, forumala) {
            this._formula = forumala;
            this._title = courseName;
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