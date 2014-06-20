function createImagesPreviewer(selector, items) {
    if (!Element.prototype.addClassName) {
        Element.prototype.addClassName = function (name) {
            if (!this.hasClassName(name)) {
                this.className = this.className ? [this.className, name].join(' ') : name;
            }
        };
    }

    if (!Element.prototype.removeClassName) {
        Element.prototype.removeClassName = function (name) {
            if (this.hasClassName(name)) {
                var c = this.className;
                this.className = c.replace(new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)", "g"), "");
            }
        };
    }

    if (!Element.prototype.hasClassName) {
        Element.prototype.hasClassName = function (name) {
            return new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)").test(this.className);
        };
    }

    var componentHeight = 600;
    var imageWidth = 100;
    var searchBoxCaseSensitive = false;
    var imagePreviewerComponent = document.querySelector(selector);
    var thumbnailReference = [];
    var normalBackgroundColor = 'white';
    var hoveredBackgroundColor = 'darkgrey';
    var documentFragment = window.document.createDocumentFragment();
    var imageContainer = document.createElement('div');
    var thumbnails = imageContainer.cloneNode(true);
    var imageLargeView = imageContainer.cloneNode(true);
    var imagePreviewerOwnClass = 'image-previewer-plugin';

    imagePreviewerComponent.style.height = componentHeight + 'px';
    imagePreviewerComponent.style.border = '5px solid blue';
    imagePreviewerComponent.style.padding = 15 + 'px';
    imagePreviewerComponent.style.display.overflow = 'hidden';
    imagePreviewerComponent.style.width = '500px';
    imagePreviewerComponent.addClassName(imagePreviewerOwnClass);

    imageLargeView.style.width = '600 px';
    imageLargeView.addClassName('large-image-container');
    imageContainer.addClassName(imagePreviewerOwnClass);
    imageContainer.addClassName('image-container');

    var title = document.createElement('p');
    title.style.textAlign = 'center';
    var image = document.createElement('img');

    var largeImage = image.cloneNode(true);
    var largeTitle = document.createElement('h1');
    largeTitle.style.textAlign = 'center';
    largeImage.style.width = 350 + 'px';

    largeTitle.style.fontWeight = 'bolder';

    imageLargeView.appendChild(largeTitle);
    imageLargeView.appendChild(largeImage);

    title.addClassName('title');
    image.addClassName('image');

    imageContainer.style.display = 'inline-block';
    image.style.width = imageWidth + 'px';

    thumbnails.addClassName(imagePreviewerOwnClass);
    thumbnails.addClassName('thumbnails');
    thumbnails.style.overflowY = 'auto';
    thumbnails.style.width = imageWidth + 30 + 'px';
    thumbnails.style.float = 'right';
    thumbnails.style.height = componentHeight + 'px';

    var searchBox = document.createElement('input');
    searchBox.type = 'text';
    searchBox.style.width = imageWidth + 'px';
    thumbnails.appendChild(searchBox);


    var searchType = function searchType() {
        var typedText = this.value;
        var isEmpty = typedText.trim().length === 0;
        if (!isEmpty) {
            showOnlyMatchingThumbs(typedText);
        }
        else {
            showAllThumbs();
        }
    };

    function showAllThumbs() {
        for (var i = 0, len = thumbnailReference.length; i < len; i++) {
            var obj = thumbnailReference[i];
            obj.style.display = 'block';
        }
    }

    function showOnlyMatchingThumbs(typedText) {
        for (var i = 0, len = thumbnailReference.length; i < len; i++) {
            var obj = thumbnailReference[i];
            var objTitle = obj.getElementsByClassName('title')[0].textContent;
            if (objTitle) {
                if (!searchBoxCaseSensitive) {
                    if (objTitle.toLocaleLowerCase().indexOf(typedText.toLocaleLowerCase()) === -1) {
                        obj.style.display = 'none';
                    }
                }
                else if (objTitle.indexOf(typedText) === -1) {
                    obj.style.display = 'none';
                }
            }
        }
    }

    function generateNewNode(item) {
        var newTitleNode = title.cloneNode(true);
        var newImageNode = image.cloneNode(true);
        var newImageContainerNode = imageContainer.cloneNode(true);
        newTitleNode.textContent = item.title;
        newImageNode.src = item.url;
        newImageContainerNode.appendChild(newTitleNode);
        newImageContainerNode.appendChild(newImageNode);
        newImageContainerNode.addEventListener('mouseover', onImageMouseOver);
        newImageContainerNode.addEventListener('mouseout', onImageMouseOut);
        newImageContainerNode.addEventListener('click', onImageMouseClick);
        return newImageContainerNode;
    }

    var onImageMouseClick = function onImageMouseClick() {
        var thisTitle = this.getElementsByClassName('title')[0];
        var thisImage = this.getElementsByClassName('image')[0];
        largeTitle.textContent = thisTitle.textContent;
        largeImage.src = thisImage.src;
    };

    var onImageMouseOver = function onImageMouseOver() {
        this.style.backgroundColor = hoveredBackgroundColor;
    };

    var onImageMouseOut = function onImageMouseOut() {
        this.style.backgroundColor = normalBackgroundColor;
    };

    for (var i = 0; i < items.length; i++) {
        var currentThumbnail = generateNewNode(items[i]);
        thumbnails.appendChild(currentThumbnail);
        thumbnailReference.push(currentThumbnail);
    }

    var firstTitle = thumbnailReference[0].getElementsByClassName('title')[0];
    var firstImage = thumbnailReference[0].getElementsByClassName('image')[0];
    largeTitle.textContent = firstTitle.textContent;
    largeImage.src = firstImage.src;

    searchBox.addEventListener('textInput', searchType);
    searchBox.addEventListener('keyup', searchType);

    documentFragment.appendChild(thumbnails);
    documentFragment.appendChild(imageLargeView);
    imagePreviewerComponent.appendChild(documentFragment);
}