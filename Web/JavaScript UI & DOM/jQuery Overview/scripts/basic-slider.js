(document.onload = function () {
    var $firstItem = $('#slider').find('.slider-item').first();
    var rotationInterval = 5000;
    var $currentItem = $firstItem;
    $firstItem.show();

    var rotateSlides = function rotateSlides() {
        $currentItem.hide();
        $currentItem = $currentItem.nextOrFirst('.slider-item');
        $currentItem.show();
        setTimeout(rotateSlides, rotationInterval);
    };

    $('#rightBtn').on('click', function(){
        $currentItem.hide();
        $currentItem = $currentItem.nextOrFirst('.slider-item');
        $currentItem.show();
    });

    $('#leftBtn').on('click', function(){
        $currentItem.hide();
        $currentItem = $currentItem.prevOrLast('.slider-item');
        $currentItem.show();
    });

    setTimeout(rotateSlides, rotationInterval);
}());


$.fn.nextOrFirst = function(selector)
{
    var next = this.next(selector);
    return (next.length) ? next : this.prevAll(selector).last();
};

$.fn.prevOrLast = function(selector)
{
    var prev = this.prev(selector);
    return (prev.length) ? prev : this.nextAll(selector).last();
};