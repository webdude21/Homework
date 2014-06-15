window.onload = function (){
    $('#books-list').listview(books);
    $('#students-table').listview(students);
};

$.fn.listview = function(collection) {
    var $that = this,
        templateId = $that.attr('data-template'),
        templateSource = $('#' + templateId).html(),
        template = Handlebars.compile(templateSource);

    collection.forEach(function(object) {
        var generatedHTML = template(object);
        $that.append(generatedHTML);
    });

    return $that;
};