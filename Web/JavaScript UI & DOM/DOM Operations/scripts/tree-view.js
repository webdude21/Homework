function appendTreeView() {
    var treeView = document.getElementById('three-view');

    var handleClick = function () {
        if (this.hideChildren) {
            this.hideChildren = false;
            showChildren(this);
        }
        else {
            this.hideChildren = true;
            hideChildren(this);
        }
    };

    function initialize(treeView) {
        attachEvent(treeView, 'click', handleClick, true);
        for (var node = 0, len = treeView.children.length; node < len; node++) {
            hideChildren(treeView.children[node], false);
            treeView.children[node].hideChildren = true;
        }
    }

    function attachEvent(treeView, event, handler, recursive){
        for (var node = 0, len = treeView.children.length; node < len; node++) {
            treeView.children[node].addEventListener(event, handler, false);
            if (recursive){
                attachEvent(treeView.children[node], event, handler, recursive)
            }
        }
    }

    function hideChildren(item, recursive) {
        for (var i = 0, len = item.children.length; i < len; i++) {
            item.children[i].style.display = 'none';
            if (recursive) {
                hideChildren(item.children[i], recursive);
            }
        }
    }

    function showChildren(item) {
        for (var i = 0, len = item.children.length; i < len; i++) {
            item.children[i].style.display = 'block';
        }
    }

    initialize(treeView);
}