$('#test').on('click', generateTable);

function generateTable() {
    var documentFragment = document.createDocumentFragment();
    var $table = $('<table>').appendTo(documentFragment);
    var $tableHead = $('<thead>').appendTo($table);
    var $tableRow = $('<tr>').appendTo($tableHead);
    $tableRow.append($('<th>').text('First name'));
    $tableRow.append($('<th>').text('Last name'));
    $tableRow.append($('<th>').text('Grade'));
    var $tableBody = $('<tbody>').appendTo($table);

    for (var index in testData) {
        var $currentRow = $('<tr>');
        $currentRow.append($('<td>').text(testData[index].firstName));
        $currentRow.append($('<td>').text(testData[index].lastName));
        $currentRow.append($('<td>').text(testData[index].grade));
        $currentRow.appendTo($tableBody);
    }

    $(documentFragment).appendTo('body');
}

var testData = [
    {
        firstName: 'Georgi',
        lastName: 'Gankov',
        grade: 3
    },
    {
        firstName: 'Petar',
        lastName: 'Borisov',
        grade: 6
    },
    {
        firstName: 'Gergana',
        lastName: 'Petrova',
        grade: 5
    },
    {
        firstName: 'Boris',
        lastName: 'Boykov',
        grade: 7
    }
];
