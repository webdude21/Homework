define([], function () {
    'use strict';
    var Item;
    Item = (function () {

        var NAME_MIN_LENGTH = 6;
        var NAME_MAX_LENGTH = 40;
        var VALID_ITEM_TYPES = {
            'accessory': 'accessory',
            'smart-phone': 'smart-phone',
            'notebook': 'notebook',
            'pc': 'pc',
            'tablet': 'tablet'
        };

        // Item validation functions
        function _validateString(variable) {
            if (!(typeof variable == 'string' || variable instanceof String)) {
                throw new TypeError('The type of the item should be a string');
            }
        }

        function _validateItemType(itemType) {
            _validateString(itemType);
            if (!VALID_ITEM_TYPES[itemType]) {
                throw new RangeError("The only possible types are: " +
                    "'accessory', 'smart-phone', 'notebook', 'pc' or 'tablet'");
            }
        }

        function _validateItemName(itemName) {
            _validateString(itemName);
            if (itemName.length < NAME_MIN_LENGTH && itemName.length > NAME_MAX_LENGTH) {
                throw new RangeError('The name of the Item should be between '
                    + NAME_MIN_LENGTH + ' and ' + NAME_MAX_LENGTH + ' characters long!');
            }
        }

        function _validateItemPrice(itemPrice) {
            if (isNaN(itemPrice)) {
                throw new TypeError('The item price should be a ' +
                    'decimal floating-point number')
            }
        }

        // Item function constructor
        function Item(itemType, itemName, itemPrice) {
            _validateItemType(itemType);
            this.type = itemType;
            _validateItemName(itemName);
            this.name = itemName;
            _validateItemPrice(itemPrice);
            this.price = itemPrice;
        }

        return Item;
    }());
    return Item;
});