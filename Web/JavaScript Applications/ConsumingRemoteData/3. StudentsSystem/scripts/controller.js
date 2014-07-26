var Controllers = (function () {

    var StudentController = (function () {
        function StudentController(dataFetcher) {
            this.dataFetcher = dataFetcher;
        }

        StudentController.prototype.displayStudents = function (selector) {
            this.dataFetcher.getAllStudents(function (data) {
                var stringResult = '';

                data.students.forEach(function (student) {
                    stringResult += student.id + '. ' +
                        student.name + ' - ' + student.grade + '\r\n';
                });

                $(selector).append(stringResult);

            }, function (err) {
                alert(JSON.stringify(err));
            });
        };

        StudentController.prototype.addStudent = function () {
            var student = {
                name: $('#tb-student-name').val(),
                grade: $('#tb-student-grade').val()
            };

            this.dataFetcher.postStudent(student, function () {
                alert('Successfully added the student!');
            }, function (err) {
                alert(err);
            });
        };

        StudentController.prototype.deleteStudent = function () {
            this.dataFetcher.deleteStudent($('#ta-student-id').val(), function (data) {
                alert(data.message);
            }, function (data) {
                alert(data.message);
            });
        };

        return StudentController;
    }());

    return {
        getStudentController: function (dataFetcher, selector) {
            return new StudentController(dataFetcher, selector);
        }
    }
}());