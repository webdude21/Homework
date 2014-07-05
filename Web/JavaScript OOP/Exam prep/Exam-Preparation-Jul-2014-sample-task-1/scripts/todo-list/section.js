define(['./item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this.title = title;
            this._items = [];
        }

        return Section;
    }());

    Section.prototype.getData = function () {
        var resultItems = [];

        this._items.forEach(function (item) {
            resultItems.push(item.getData());
        });

        return {
            title: this.title,
            items: resultItems
        }
    };

    Section.prototype.add = function (item) {
        if (item instanceof Item) {
            this._items.push(item);
        } else {
            throw new TypeError('You must supply an object of the Item type.')
        }

        return this;
    };

    return Section;
});