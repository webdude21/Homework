define(['./section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._items = [];
        }

        return Container;
    }());

    Container.prototype.add = function (section) {
        if (section instanceof Section) {
            this._items.push(section);
        } else {
            throw new TypeError('You must supply an object of the Section type.')
        }
        return this;
    };

    Container.prototype.getData = function () {
        var result = [];
        this._items.forEach(function (section) {
            result.push(section.getData());
        });
        return result;
    };

    return Container;
});