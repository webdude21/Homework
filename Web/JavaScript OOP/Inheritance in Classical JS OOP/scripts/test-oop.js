function testOOP() {
    var testCapacity = 30;
    var testStudentArr = [];

    for (var i = 0; i < testCapacity; i++) {
        testStudentArr.push(new schoolSystem.Student('Petar ' + i, 'Petrov', 12, i + 1))
    }

    var testTeacher = new schoolSystem.Teacher('Georgi', 'Gankov', 42, 'Physics');
    var testClass = new schoolSystem.SchoolClass('7a', testTeacher, testCapacity, testStudentArr);
    var testSchool = new schoolSystem.School('Middleton High', 'Boston');

    testSchool.addClass(testClass);

    jsConsole.writeLine(testTeacher.intoduce());
}