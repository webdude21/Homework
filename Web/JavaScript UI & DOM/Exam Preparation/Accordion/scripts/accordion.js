function getAccordion(selector) {
    var accordionHolder = document.querySelector(selector);
    var currentItem = document.createElement('div');
    var prototypeLi = document.createElement('div');

    accordionHolder.add = function add(content) {
        var currentLi = prototypeLi.cloneNode(true);
        currentItem.appendChild(currentLi);
    }
}