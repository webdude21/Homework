window.addEventListener('load', function () {
    'use strict';
    var optionSelect = document.getElementById('task-select');
    var clearButton = document.getElementById('clear-console');
    var testButton = document.getElementById('test-button');
    var console = document.getElementById('js-console');

    clearButton.addEventListener('click', jsConsole.clear);

    testButton.addEventListener('click', function () {
        switch (optionSelect.selectedIndex) {
            case 0:
                underScoreJSHomework.filterAndSortStudents();
                break;
            case 1:
                underScoreJSHomework.filterStudentsByAge();
                break;
            case 2:
                underScoreJSHomework.getStudentWithTheHighestMarks();
                break;
            case 3:
                underScoreJSHomework.groupAnimalsByIDAndSortByNumberOfLegs();
                break;
            case 4:
                underScoreJSHomework.sumLegsAmount();
                break;
            case 5:
                underScoreJSHomework.findMostPopularAuthor();
                break;
            case 6:
                underScoreJSHomework.findMostCommonFirstAndLastName();
                break;
        }
    });
});

