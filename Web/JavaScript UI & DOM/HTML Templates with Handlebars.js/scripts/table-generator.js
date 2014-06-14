window.onload = generateTable;

function generateTable() {
    var tableTemplateHTML = document.getElementById('select-template').innerHTML;
    var tableTemplate = Handlebars.compile(tableTemplateHTML);
    document.getElementById('wrapper').innerHTML = tableTemplate(courses);
}