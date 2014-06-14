$('#test').on('click', test);

function test() {
    $('dropdown').dropdown()
}

$.fn.dropdown = function dropdown() {
    var $this = $(this);
    var $listItems = $('option');

    $this.hide();
    var $ul = $('<ul class="dropdown-list-options">');
    var $container = $('<div class="dropdown-list-container">').
        append($ul);

    function convertOption($currentItem) {
        $('<li class="dropdown-list-option">')
            .data('data-value', item)
            .text($currentItem.text())
            .on('click', toggleCheck)
            .appendTo($ul);
    }

    var clearSelection = function (index, item){
        $(item).removeAttr('selected');
    };

    var toggleCheck = function toggleCheck(event) {
        var $optionItem = $($listItems[$(event.target).data('data-value')]);
        if ($optionItem.attr('selected') == 'selected') {
            $optionItem.each(clearSelection);
        }
        else {
            $listItems.each(clearSelection);
            $optionItem.attr('selected', 'selected');
        }
    };

    for (var item = 0; item < $listItems.length; item++) {
        convertOption($($listItems[item]));
    }
    $('body').append($container);
};