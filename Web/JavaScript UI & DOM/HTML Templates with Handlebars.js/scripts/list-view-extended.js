window.onload = function () {
    $('#students-table').listview(students);
};

$.fn.listview = function (collection) {
    var $that = this;
    var templateSource = $that.html();
    var template = Handlebars.compile(templateSource);
    $that.html(''); // clear the template

    collection.forEach(function (object) {
        var generatedHTML = template(object);
        $that.append(generatedHTML);
    });

    return $that;
};

