/// <reference path="zoo.ts"/>
/// <reference path="school-system.ts"/>

function testSchoolSystem() {

    var testCapacity = 30;
    var testStudentArr = [];

    for (var i = 0; i < testCapacity; i++) {
        testStudentArr.push(new schoolSystem.Student('Petar ' + i, 'Petrov', 12, i + 1));
    }

    var testTeacher = new schoolSystem.Teacher('Georgi', 'Gankov', 42, 'Physics');
    var testClass = new schoolSystem.SchoolClass(testTeacher);
    testClass.addStudents(testStudentArr);
}

function testZoo() {
    var testContainer = document.getElementById('test-output');

    var cage = new Zoo.AnimalCage<Zoo.IAnimal>(16);
    var polarBearPepi = new Zoo.PolarBear("Pepi");
    var kaaSnake = new Zoo.Snake("Kaa");
    var nickMonkey = new Zoo.Monkey("Nick");
    var mimiSeaTurtle = new Zoo.SeaTurtle("Mimi");

    cage.addAnimal(polarBearPepi);
    cage.addAnimal(kaaSnake);
    cage.addAnimal(nickMonkey);
    cage.addAnimal(mimiSeaTurtle);

    testContainer.textContent = cage.toString();
}