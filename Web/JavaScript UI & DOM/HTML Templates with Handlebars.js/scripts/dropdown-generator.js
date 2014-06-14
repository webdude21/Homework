window.onload = generateDropdown;

function generateDropdown() {
    var selectHTMLTemplate = document.getElementById('select-template').innerHTML;
    var selectTemplate = Handlebars.compile(selectHTMLTemplate);
    document.getElementById('wrapper').innerHTML = selectTemplate(items);
}