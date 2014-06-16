$('#test').on('click', test);

function test() {
    $('<p> inserted before </p>').insertBefore('#divider');
    $('<p> inserted after </p>').insertAfter('#divider');
}

function insertAfter(element) {
    this.after($('element'));
}

function insertBefore(event) {
    this.before($('element'));
}