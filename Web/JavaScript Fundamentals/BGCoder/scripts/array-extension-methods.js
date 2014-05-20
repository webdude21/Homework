Array.prototype.unset = function (value) {
    if (this.indexOf(value) !== -1) { // Make sure the value exists
        this.splice(this.indexOf(value), 1);
    }
};