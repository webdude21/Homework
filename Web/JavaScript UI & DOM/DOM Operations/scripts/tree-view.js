function generateTreeView() {
    var liElements = document.getElementsByTagName('li');

    var showHideChildren = function (event) {
        event.stopPropagation();
        for (var i = 0, len = this.children.length; i < len; i++) {
            this.children[i].style.display =
                    this.children[i].style.display == 'none' ? 'block' : 'none';
        }
    };

    function initializeTreeView(event, handler, collection) {
        for (var i = 0, len = collection.length; i < len; i++) {
            hideChildren(collection[i]);
            collection[i].addEventListener(event, handler, false)
        }
    }

    function hideChildren(node) {
        for (var i = 0, len = node.children.length; i < len ; i++) {
            node.children[i].style.display = 'none';
        }
    }

    initializeTreeView('click', showHideChildren, liElements);
}