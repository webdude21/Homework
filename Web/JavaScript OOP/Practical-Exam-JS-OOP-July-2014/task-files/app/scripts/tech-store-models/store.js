define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        var NAME_MIN_LENGTH = 6;
        var NAME_MAX_LENGTH = 40;
        var SMART_PHONES = ['smart-phone'];
        var MOBILES = ['smart-phone', 'tablet'];
        var COMPUTERS = ['pc', 'notebook'];
        var ITEM_NAME_PROPERTY = 'name';
        var ITEM_TYPE_PROPERTY = 'type';

        // Validation methods
        function _validateString(variable) {
            if (!(typeof variable == 'string' || variable instanceof String)) {
                throw new TypeError('The type of the item should be a string');
            }
        }

        function _validateStoreName(storeName) {
            _validateString(storeName);
            if (storeName.length < NAME_MIN_LENGTH && storeName.length > NAME_MAX_LENGTH) {
                throw new RangeError('The name of the Store should be between '
                    + NAME_MIN_LENGTH + ' and ' + NAME_MAX_LENGTH + ' characters long!');
            }
        }

        function _validateItem(storeItem) {
            if (!storeItem instanceof Item) {
                throw new TypeError('You are only allowed to ' +
                    'add the instances of Item to the Store');
            }
        }

        // helper internal functions
        function _sortByPropertyName(property, arrayToSort) {
            arrayToSort.sort(function (itemA, ItemB) {
                if (itemA[property] < ItemB[property]) {
                    return -1;
                }
                if (itemA[property] > ItemB[property]) {
                    return 1;
                }
                return 0;
            });
        }

        function _getItemByTypeSortedByProperty(itemTypes, itemsCollection, property) {
            var result = _getItemsByType(itemTypes, itemsCollection);

            _sortByPropertyName(property, result);

            return result;
        }

        function _getItemsByType(itemTypes, itemsCollection) {
            var result = [];

            itemsCollection.forEach(function (storeItem) {
                if (itemTypes.indexOf(storeItem.type) > -1) {
                    result.push(storeItem);
                }
            });

            return result;
        }

        function _filterByProperty(property, filter, itemsToFilter) {
            var result = [];
            itemsToFilter.forEach(function (item) {
                if (item[property] === filter) {
                    result.push(item);
                }
            });

            return result;
        }

        // Store Function Constructor
        function Store(storeName) {
            _validateStoreName(storeName);
            this.name = storeName;
            this._storeItems = [];
        }

        // Store exposed methods
        Store.prototype.addItem = function (storeItem) {
            _validateItem(storeItem);
            this._storeItems.push(storeItem);
			return this;
        };

        Store.prototype.getAll = function () {
            var result = this._storeItems.slice();
            _sortByPropertyName(ITEM_NAME_PROPERTY, result);
            return result;
        };

        Store.prototype.getSmartPhones = function () {
            return _getItemByTypeSortedByProperty(SMART_PHONES,
                this._storeItems, ITEM_NAME_PROPERTY);

        };

        Store.prototype.getMobiles = function () {
            return _getItemByTypeSortedByProperty(MOBILES,
                this._storeItems, ITEM_NAME_PROPERTY);
        };

        Store.prototype.getComputers = function () {
            return _getItemByTypeSortedByProperty(COMPUTERS,
                this._storeItems, ITEM_NAME_PROPERTY);

        };

        Store.prototype.filterItemsByType = function (filterType) {
            var result = _filterByProperty(ITEM_TYPE_PROPERTY,
                filterType, this._storeItems);
            _sortByPropertyName(ITEM_NAME_PROPERTY, result);
            return result;
        };

        Store.prototype.filterItemsByPrice = function (priceRange) {
            var result = [];

            if (priceRange) {
                var min = priceRange.min || 0;
                var max = priceRange.max || Infinity;

                this._storeItems.forEach(function (item) {
                    if (item.price > min && item.price < max) {
                        result.push(item);
                    }
                });

            } else {
                result = this._storeItems.slice();
            }

            _sortByPropertyName('price', result);

            return result;
        };

        Store.prototype.countItemsByType = function () {
            var result = {};

            this._storeItems.forEach(function (item) {
                if (result[item.type]) {
                    result[item.type] += 1;
                } else {
                    result[item.type] = 1;
                }
            });

            return result;
        };

        Store.prototype.filterItemsByName = function (name) {
            var result = [];
            this._storeItems.forEach(function (item) {
                if (item.name.toLocaleLowerCase().indexOf(name.toLocaleLowerCase()) > -1) {
                    result.push(item);
                }
            });

            _sortByPropertyName(ITEM_NAME_PROPERTY, result);

            return result;
        };

        return Store;
    }());

    return Store;
});