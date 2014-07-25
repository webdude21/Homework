(function () {

    var containerSelector = '#wrapper';
    var rootUrl = 'http://localhost:3000/students';
    var dataFetcher = DataFetcher.getFetcher(rootUrl);
    var controller = Controllers.getStudentController(dataFetcher, containerSelector);
    $(containerSelector).on('click', '#btn-get-students', function () {
        controller.displayStudents('#ta-all-students');
        return false;
    });
}());