var Controllers = (function () {

    var StudentController = (function () {
        function StudentController(dataFetcher, selector) {
            this.dataFetcher = dataFetcher;
            this.selector = selector;
        }

        StudentController.prototype.displayStudents = function (selector) {
            this.dataFetcher.getAllStudents(function (data) {
                var stringResult = '';

                data.students.forEach(function (student) {
                    stringResult += student.id.toString() + '. '
                        student.name + student.grade.toString() + '\r\n';
                });

                $(selector).append(stringResult);

            }, function (err) {
                alert(JSON.stringify(err));
            });
        };

        StudentController.prototype.addStudent = function (student) {
            this.dataFetcher.postStudent(student, function (data) {
                console.log('yea');
            }, function (err) {
                console.log('nope');
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