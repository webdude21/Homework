function generateDivs(divCount) {
    var documentFragment = document.createDocumentFragment();
    var strong = document.createElement('strong');
    strong.textContent = 'div';

    function getRandomDiv(nestedElement) {
        var newDIv = document.createElement('div');
        newDIv.style.color = getRandomColor();
        newDIv.style.backgroundColor = getRandomColor();
        newDIv.style.border = getRandomColor(1, 20) + 'px solid ' + getRandomColor();
        newDIv.style.position = 'absolute';
        newDIv.style.top = getRandomInt(0, 800) + 'px';
        newDIv.style.left = getRandomInt(0, 1600) + 'px';
        newDIv.style.height = getRandomInt(20, 100) + 'px';
        newDIv.style.width = getRandomInt(20, 100) + 'px';
        newDIv.style.borderRadius = getRandomInt(0, 100000) + 'px';
        newDIv.appendChild(nestedElement);
        newDIv.className = 'my-div';
        return newDIv
    }

    function getRandomInt(from, to) {
        return Math.floor(Math.random() * (to - from) + from);
    }

    function getRandomColor() {
        return '#' + Math.floor(Math.random() * 16777215).toString(16);
    }

    for (var i = 0; i < divCount; i++) {
        documentFragment.appendChild(getRandomDiv(strong.cloneNode(true)))
    }

    return documentFragment;
}