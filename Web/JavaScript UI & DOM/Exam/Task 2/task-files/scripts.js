$.fn.gallery = function gallery(columnsPerRow) {
    var columns = columnsPerRow || 4;
    var $galleryContainer = $(this);
    var selected = '.selected';
    $galleryContainer.addClass('gallery');
    var blurred = 'blurred';
    var backgroundClickable = true;

    var imageContainerWidht = parseInt($('.gallery .image-container').css('width'));
    $galleryContainer.css('width', (imageContainerWidht * columns * 1.05) + 'px');
    var $notSelectedImages = $galleryContainer.
        find('.gallery-list').
        find('.image-container');

    var $selectedDiv = $galleryContainer
        .find('.selected');
    $selectedDiv.hide();

    function changeCurrentSelection($this) {
        var thisImage = $this.find('img').attr('src');
        var thisNextImage = $this.nextOrFirst().find('img').attr('src');
        var thisPreviousImage = $this.prevOrLast().find('img').attr('src');

        var currentImage = $galleryContainer.find('#current-image');
        var previousImage = $galleryContainer.find('#previous-image');
        var nextImage = $galleryContainer.find('#next-image');

        currentImage.attr('src', thisImage);
        previousImage.attr('src', thisPreviousImage);
        nextImage.attr('src', thisNextImage);
    }

    var onSelectedImageClick = function onSelectedImageClick() {
        var $this = $(this);
        if ($this.hasClass('current-image')) {
            $selectedDiv.hide();
            $notSelectedImages.removeClass('blurred');
            backgroundClickable = true;
        }
        else {
            changeCurrentSelection($this);
            backgroundClickable = false;
        }
    };

    var $selectedImages = $selectedDiv.find('div');
    $selectedImages.each(function (index, item) {
            $(item).on('click', onSelectedImageClick);
        }
    );

    var onNotSelectedImageClick = function onNotSelectedImageClick() {
        if (backgroundClickable === true) {
            var $this = $(this);
            backgroundClickable = false;
            changeCurrentSelection($this);
            $selectedDiv.show();
            $notSelectedImages.addClass('blurred');
        }
    };

    $notSelectedImages.each(function (index, item) {
            $(item).on('click', onNotSelectedImageClick);
        }
    )
};

$.fn.nextOrFirst = function (selector) {
    var next = this.next(selector);
    return (next.length) ? next : this.prevAll(selector).last();
};

$.fn.prevOrLast = function (selector) {
    var prev = this.prev(selector);
    return (prev.length) ? prev : this.nextAll(selector).last();
};