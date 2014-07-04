define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            this._content = content;
        }

        return Item;
    })();

    Item.prototype.getData = function () {
        return {
            content: this._content
        }
    };
    return Item;
});