define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            this.content = content;
        }

        return Item;
    })();

    Item.prototype.getData = function () {
       return {
           content: this.content
       }
    };
    return Item;
});