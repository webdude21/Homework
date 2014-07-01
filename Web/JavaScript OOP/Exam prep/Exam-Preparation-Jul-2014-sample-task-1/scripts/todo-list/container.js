define(function () {
    'use strict';
    var Container;
    Container = (function () {

        function Container() {
            this._content = [];
        }

        return Container;
    }());

    Container.prototype.add = function (section) {
        if (section /* instanceof Section */) {
            this._content.push(section);
        } else {
            throw new TypeError('You must supply an object of the Section type.')
        }
    };

    Container.prototype.getData = function () {
        var result = [];
        this._content.forEach(function (section) {
            result.push(section.getData());
        });

        return result;
    };
    return Container;
});