$('#test').on('click', test);

function test() {
    $('<p> inserted before </p>').insertBefore('#divider');
    $('<p> inserted after </p>').insertAfter('#divider');
}