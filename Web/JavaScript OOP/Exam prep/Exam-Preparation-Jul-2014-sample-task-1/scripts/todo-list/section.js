define(['./item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._title = title;
            this._items = [];
        }

        return Section;
    }());

    Section.prototype.getData = function () {
        return {
            title: this._title,
            items: this._items
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