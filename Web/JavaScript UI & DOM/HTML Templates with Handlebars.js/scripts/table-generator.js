window.onload = generateTable;

function generateTable() {
    var tableTemplateHTML = document.getElementById('table-template').innerHTML;
    var tableTemplate = Handlebars.compile(tableTemplateHTML);
    document.getElementById('wrapper').innerHTML = tableTemplate(courses);
}