var domModule = (function () {
    function appendChild(domNode, selector) {
        var selected = getElementsBySelector(selector);

        if (selected.length) {
            var documentFragment = document.createDocumentFragment();

            selected.forEach(function () {
                documentFragment.appendChild(item);
            }, item);

            domNode.appendChild(documentFragment);
        }
    }

    function getElementsBySelector(selector) {
        return document.querySelectorAll(selector);
    }
}());