var NodeCache = require("node-cache");
var cacheTimeInMinutes = 10;
var cacheTime = cacheTimeInMinutes * 60;

var myCache = new NodeCache({ stdTTL: cacheTime, checkperiod: 120 });

module.exports = {
    getFromCache: function (error, success, key) {
        myCache.get(key, function (err, value) {
            if (err) {
                error();
            } else {
                if (value[key]) {
                    success(value);
                } else {
                    error();
                }
            }
        });
    },
    putInCache: function (key, obj) {
        myCache.set(key, obj, cacheTime);
    }
};